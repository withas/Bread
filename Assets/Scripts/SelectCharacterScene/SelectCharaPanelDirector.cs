using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public sealed class SelectCharaPanelDirector : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private StatusPanelDirector statusPanelDirector;

    [SerializeField]
    private CharaButtonsDirector charaButtonsDirector;

    [SerializeField]
    private DisplayCharaDirector displayCharaDirector;

    [SerializeField]
    private GameObject buttonsPanel;

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

    private Characters selectedChara;

    public IObservable<Characters> GetSelectedObservable()
    {
        return selectButton.OnClickAsObservable()
                           .Select(_ => selectedChara);
    }

    public void SetPlayerIndex(int value)
    {
        playerLabelFrontText.text = playerLabelBackText.text = $"Player {value + 1}";

        if (value != 0)
        {
            rectTransform.anchoredPosition = new Vector2(-rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
        }
    }

    private void Start()
    {
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

        selectButton.OnClickAsObservable()
                    .FirstOrDefault()
                    .Subscribe(_ => buttonsPanel.SetActive(false))
                    .AddTo(buttonsPanel);
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
