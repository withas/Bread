using UnityEngine;
using UnityEngine.UI;
using UniRx;

public sealed class SelectCharaPanelDirector : MonoBehaviour
{
    [SerializeField]
    private StatusPanelDirector statusPanelDirector;

    [SerializeField]
    private CharaButtonsDirector charaButtonsDirector;

    [SerializeField]
    private DisplayCharaDirector displayCharaDirector;

    [SerializeField]
    private Button selectCurryButton;

    [SerializeField]
    private Button selectFranceButton;

    [SerializeField]
    private Button selectMelonButton;

    [SerializeField]
    private Button selectCornetButton;

    private void Start()
    {
        selectCurryButton.OnClickAsObservable()
                         .Select(_ => Characters.Curry)
                         .Subscribe(OnSelectCharaButtonClicked)
                         .AddTo(this);

        selectFranceButton.OnClickAsObservable()
                          .Select(_ => Characters.France)
                          .Subscribe(OnSelectCharaButtonClicked)
                          .AddTo(this);

        selectMelonButton.OnClickAsObservable()
                         .Select(_ => Characters.Melon)
                         .Subscribe(OnSelectCharaButtonClicked)
                         .AddTo(this);

        selectCornetButton.OnClickAsObservable()
                          .Select(_ => Characters.Cornet)
                          .Subscribe(OnSelectCharaButtonClicked)
                          .AddTo(this);
    }

    private void OnSelectCharaButtonClicked(Characters character)
    {
        statusPanelDirector.SetStatus(character);
        charaButtonsDirector.SetBgActive(character);
        displayCharaDirector.Display(character);
    }
}
