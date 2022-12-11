using System;
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

    [SerializeField]
    private Button selectButton;

    [SerializeField]
    private Text playerLabelFrontText;

    [SerializeField]
    private Text playerLabelBackText;

    [SerializeField]
    private int playerNumber = 0;

    private Characters selectedChara;

    public IObservable<Characters> GetSelectedObservable()
    {
        return selectButton.OnClickAsObservable()
                           .Select(_ => selectedChara);
    }

    private void Start()
    {
        playerLabelFrontText.text = playerLabelBackText.text = $"Player {playerNumber + 1}";

        Observable.Merge(selectCurryButton.OnClickAsObservable()
                                          .Select(_ => Characters.Curry),
                         selectFranceButton.OnClickAsObservable()
                                           .Select(_ => Characters.France),
                         selectMelonButton.OnClickAsObservable()
                                          .Select(_ => Characters.Melon),
                         selectCornetButton.OnClickAsObservable()
                                           .Select(_ => Characters.Cornet))
                  .Subscribe(OnSelectCharaButtonClicked)
                  .AddTo(this);
    }

    private void OnSelectCharaButtonClicked(Characters character)
    {
        this.selectedChara = character;

        statusPanelDirector.SetStatus(character);
        charaButtonsDirector.SetBgActive(character);
        displayCharaDirector.Display(character);

        selectButton.gameObject.SetActive(true);
    }
}
