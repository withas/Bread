using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private CharaStatusData charaStatusData;

    // ガード関係
    [SerializeField]
    private GameObject barrierPrefab;

    // バリアのオブジェクトを入れる
    private GameObject barrier;
    private bool isGuarding;

    private Slider slider;

    private Rigidbody2D rigidBody; // Rigidbodyコンポーネント
    protected Animator animator; // Animatorコンポーネント
    private SpriteRenderer spriteRenderer;

    // ステータス状態
    private int hp; // 現在のHP

    public bool canMove; // 移動可能かどうか。アニメーションから操作する
    private bool isJumping; // ジャンプ中かどうか
    private float freezingTime; // 硬直時間。0以上のときはなにもできない

    private float inputX;

    // サウンド関連
    // 0:攻撃くらったとき, 1:スキル, 2:ガード時の被ダメ
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;

    private int playerNum;

    private Subject<Unit> onDownedSubject = new Subject<Unit>();

    public IObservable<Unit> OnDownedObservable => onDownedSubject;

    // プレイヤー1or2を識別
    public void SetPlayerNum(int num)
    {
        this.playerNum = num;

        this.slider = GameObject.Find("Canvas").transform.Find("Player" + num + "_HP").GetComponent<Slider>();
    }

    private void Awake()
    {
        onDownedSubject.AddTo(this);
    }

    protected void Start()
    {
        this.slider.maxValue = charaStatusData.MaxHP;
        this.hp = charaStatusData.MaxHP;
        this.slider.value = this.hp;

        // コンポーネントを取得する
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();

        // フラグを初期化する
        this.canMove = true;
        this.isJumping = false;
        this.isGuarding = false;

        //AudioSourse取得
        audioSource = GetComponent<AudioSource>();
    }

    protected void Update()
    {
        // 硬直時間を減らす
        if (this.freezingTime > 0)
        {
            this.animator.SetBool("IsFreezing", true);
            this.freezingTime -= Time.deltaTime;
            if (this.freezingTime <= 0) this.spriteRenderer.color = new Color(255.0f, 255.0f, 255.0f);
        }
        else this.animator.SetBool("IsFreezing", false);

        if (this.isJumping) this.animator.SetFloat("YSpeed", this.rigidBody.velocity.y);
    }

    private void FixedUpdate()
    {
        const float power = 20;

        this.rigidBody.AddForce(Vector3.right * ((charaStatusData.MoveSpeed * this.inputX - this.rigidBody.velocity.x) * power) * this.rigidBody.mass);
    }

    // 向きを変える
    public void SetDirection(float direction)
    {
        // 現在の角度を取得する
        Vector3 worldAngle = this.transform.eulerAngles;

        // 向いている方向と違う方向が渡されたとき
        if ((int)worldAngle.y == 0 && direction > 0 || (int)worldAngle.y == 180 && direction < 0)
        {
            this.transform.Rotate(0, 180f, 0); // 180度回転
        }
    }

    // どんなときでも1フレームに1回呼ばれる。xにはx軸方向の入力が渡される
    public void OnMove(float x)
    {
        // 移動禁止中、もしくは硬直中は速度を0にする
        if (!this.canMove || this.isGuarding || this.freezingTime > 0) x = 0;

        // ジャンプ中は向きを変えない
        if (!isJumping) this.SetDirection(x);

        this.animator.SetFloat("Speed", Mathf.Abs(x));

        // this.rb.velocity = new Vector2(x * this.moveSpeed, this.rb.velocity.y);
        this.inputX = x;
    }

    // ジャンプキーが押されたときに呼ばれる
    public void OnJump()
    {
        // ジャンプ中はジャンプできない
        if (this.isJumping || this.isGuarding || !this.canMove || this.freezingTime > 0) return;

        this.animator.SetTrigger("Jump");
    }

    // 着地するときにFootPointから呼ばれる
    public void OnGround()
    {
        if (this.isJumping)
        {
            this.animator.SetTrigger("OnGround");
            this.isJumping = false;
        }
    }

    // Jumpアニメーション中に呼び出す
    public void Jump()
    {
        this.rigidBody.AddForce(this.transform.up * charaStatusData.JumpForce);

        this.isJumping = true;
    }

    // Attack1ボタンが押されたときに呼ばれる
    public void OnAttack1()
    {
        if (this.isJumping || this.isGuarding || !this.canMove || this.freezingTime > 0) return;

        this.animator.SetTrigger("Attack1");
    }

    // Attack2ボタンが押されたときに呼ばれる
    public void OnAttack2()
    {
        if (this.isJumping || this.isGuarding || !this.canMove || this.freezingTime > 0) return;

        this.animator.SetTrigger("Attack2");
        audioSource.PlayOneShot(clips[1]);
    }

    // ガードキーが押されているときに呼ぶ
    public void OnGuard()
    {
        if (this.isJumping || this.isGuarding || !this.canMove || this.freezingTime > 0) return;

        // バリアを子オブジェクトとして生成する
        this.barrier = Instantiate(barrierPrefab);
        this.barrier.transform.parent = this.transform;
        this.barrier.transform.localPosition = new Vector3(0, 0.75f, 0);

        this.isGuarding = true;
    }

    // ガードキーが離されたときに呼ぶ
    public void OffGuard()
    {
        // バリアを消す
        if (this.barrier != null) Destroy(this.barrier);

        this.isGuarding = false;
    }

    // 攻撃を受けたときに呼ばれる。ダメージ量と硬直時間を引数に受け取る
    public virtual void OnDamage(int damage, float freezingTime)
    {
        if (this.hp <= 0) return; // 死んでいたらダメージを受けない

        this.animator.SetTrigger("IsHurt");

        // ダメージを受ける
        if (!isGuarding)
        {
            this.hp -= damage;

            // ダメージ音再生
            this.audioSource.PlayOneShot(clips[0]);
        }
        else
        {
            this.hp -= (int)(damage * charaStatusData.GuardingRatio);

            this.audioSource.PlayOneShot(clips[2]);
        }

        this.slider.value = this.hp;

        // HPが0以下になったら死亡する
        if (this.hp <= 0)
        {
            Die();
            return;
        }

        // ガードしていないときは硬直を設定する
        if (!isGuarding)
        {
            this.freezingTime = freezingTime;
            this.spriteRenderer.color = new Color(255.0f, 0.0f, 0.0f);
        }
    }

    // やられたときの処理
    private void Die()
    {
        this.hp = 0;

        // 死亡アニメーションに移行
        this.animator.SetTrigger("IsDead");

        // 操作不能にする
        this.enabled = false;

        onDownedSubject.OnNext(Unit.Default);
        onDownedSubject.OnCompleted();
    }
}
