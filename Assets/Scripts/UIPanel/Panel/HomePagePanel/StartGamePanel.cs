using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class StartGamePanel :UIPanelRoot, IPointerClickHandler
{
    private Image BGImage;
    private Text TipsText;
    private Image Img_Tips;
    private TweenParams colorChange;
    private bool isClick = false;

    public override void Init(UIFacade mui)
    {
        base.Init(mui);
        Img_Tips = transform.GetChild(1).GetComponent<Image>();
        TipsText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        
        colorChange = new TweenParams();
        colorChange.SetAutoKill(false);
        colorChange.SetLoops(-1, LoopType.Yoyo);
        Img_Tips.DOFade(0, 2).SetAs(colorChange);
        TipsText.DOFade(0, 2).SetAs(colorChange);
        SetActiveState(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isClick = true;
        muiFacade.ChangeSceneState(new HomePageState(muiFacade));
    }


}
