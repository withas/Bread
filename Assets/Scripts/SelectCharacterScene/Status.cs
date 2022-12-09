using UnityEngine;
using UnityEngine.UI;

public sealed class Status : MonoBehaviour
{
    private int hp = 0;

    private float attack;

    private float speed = 0;

    private float jump = 0;

    [SerializeField]
    private GameObject chara;

    [SerializeField]
    private GameObject attack2Object;

    /* 各ステータスのslider
     * 0: HP
     * 1: attack
     * 2: speed
     * 3: jump
     * 4: guard
     */
    [SerializeField]
    private  Slider[] status;

    public void ChangeStatus()
    {
        // 各攻撃の攻撃力
        int attack1Power = 0;
        int attack2Power = 0;

        switch (chara.name)
        {
            case ("Curry"):
                CurryController curryController = chara.GetComponent<CurryController>();
                // curryController.GetCharaStatus(hp, speed, jump);
                // curryController.GetStatusInfo(hp, speed, jump);
                hp = curryController.GetMaxHp();
                speed = curryController.GetSpeed();
                jump = curryController.GetJump();
                Debug.Log(hp + ", " + speed + ", " + jump);
                status[0].value = hp;
                status[2].value = speed;
                status[3].value = jump;

                // Attack1の攻撃力を取得する
                attack1Power = this.chara.transform.Find("CurryAttack1").gameObject.GetComponent<PunchController>().GetPower();

                // Attack2の攻撃力を取得する
                attack2Power = this.attack2Object.GetComponent<CurryAttack2Controller>().GetPower();

                break;
            case ("Melon"):
                MelonController melonController = chara.GetComponent<MelonController>();
                // melonController.GetCharaStatus((int)status[0].value, status[1].value, status[2].value);
                hp = melonController.GetMaxHp();
                speed = melonController.GetSpeed();
                jump = melonController.GetJump();
                Debug.Log(hp + ", " + speed + ", " + jump);
                status[0].value = hp;
                status[2].value = speed;
                status[3].value = jump;

                // Attack1の攻撃力を取得する
                attack1Power = this.chara.transform.Find("MelonAttack1").gameObject.GetComponent<PunchController>().GetPower();

                // Attack2の攻撃力を取得する
                attack2Power = this.attack2Object.GetComponent<MelonAttack2Controller>().GetPower();

                break;
            case ("France"):
                FranceController franceController = chara.GetComponent<FranceController>();
                // franceController.GetCharaStatus((int)status[0].value, status[1].value, status[2].value);
                hp = franceController.GetMaxHp();
                speed = franceController.GetSpeed();
                jump = franceController.GetJump();
                Debug.Log(hp + ", " + speed + ", " + jump);
                status[0].value = hp;
                status[2].value = speed;
                status[3].value = jump;

                // Attack1の攻撃力を取得する
                attack1Power = this.chara.transform.Find("FranceAttack1").gameObject.GetComponent<PunchController>().GetPower();

                // Attack2の攻撃力を取得する
                attack2Power = this.attack2Object.GetComponent<FranceAttack2Controller>().GetPower();

                break;
            case ("Cornet"):
                CornetController cornetController = chara.GetComponent<CornetController>();
                // cornetController.GetCharaStatus((int)status[0].value, status[1].value, status[2].value);
                hp = cornetController.GetMaxHp();
                speed = cornetController.GetSpeed();
                jump = cornetController.GetJump();
                Debug.Log(hp + ", " + speed + ", " + jump);
                status[0].value = hp;
                status[2].value = speed;
                status[3].value = jump;

                // Attack1の攻撃力を取得する
                attack1Power = this.chara.transform.Find("CornetAttack1").gameObject.GetComponent<PunchController>().GetPower();

                // Attack2の攻撃力を取得する
                attack2Power = this.attack2Object.GetComponent<CornetAttack2Controller>().GetPower();

                break;
        }

        // スライダーに各攻撃力の平均値を設定する
        this.status[1].value = (float)(attack1Power + attack2Power) / 2.0f;

        // スライダーにガード率の逆数を設定する
        this.status[4].value = 1.0f / this.chara.GetComponent<PlayerController>().GetGuardingRatio();
    }
}
