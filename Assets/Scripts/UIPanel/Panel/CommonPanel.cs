using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonPanel : UIPanelRoot
{
    public Button[] buttons;
    public Image[] images;
    public Sprite[] spriteList;
    public int currentTap = 0;
    public bool isFirst = true;

    public override void Init(UIFacade mui)
    {
        SetActiveState(true);
        if (!isFirst) { return; }
        base.Init(mui);
        spriteList = new Sprite[12];
        buttons = transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(EnterHomePageState);
        buttons[1].onClick.AddListener(EnterMapPageState);
        buttons[2].onClick.AddListener(EnterEquiPageState);
        buttons[3].onClick.AddListener(EnterShopPageState);
        buttons[4].onClick.AddListener(EnterSocialPageState);
        buttons[5].onClick.AddListener(EnterOtherPageState);

        images = transform.GetChild(0).GetChild(0).GetComponentsInChildren<Image>();
        GetSprite();
        ChangeSprite(0);
        isFirst = false;
    }

    private void EnterHomePageState()
    {
        muiFacade.ChangeSceneState(new HomePageState(muiFacade));
        ChangeSprite(0);
    }

    private void EnterMapPageState()
    {
        muiFacade.ChangeSceneState(new MapPageState(muiFacade));
        ChangeSprite(1);
    }

    private void EnterEquiPageState()
    {
        muiFacade.ChangeSceneState(new EquipPageState(muiFacade));
        ChangeSprite(2);
    }

    private void EnterShopPageState()
    {
        ChangeSprite(3);
    }

    private void EnterSocialPageState()
    {
        ChangeSprite(4);
    }

    private void EnterOtherPageState()
    {
        ChangeSprite(5);
    }

    private void ChangeSprite(int num)
    {
        images[currentTap].sprite = spriteList[currentTap * 2];
        images[num].sprite = spriteList[num * 2 + 1];
        currentTap = num;
    }

    public void GetSprite()
    {
        spriteList[0] = muiFacade.GetSpriteResource("HomePageTabUp.png");
        spriteList[1] = muiFacade.GetSpriteResource("HomePageTabDown.png");
        spriteList[2] = muiFacade.GetSpriteResource("MapTabUp.png");
        spriteList[3] = muiFacade.GetSpriteResource("MapTabDown.png");
        spriteList[4] = muiFacade.GetSpriteResource("EquipmentTabUp.png");
        spriteList[5] = muiFacade.GetSpriteResource("EquipmentTabDown.png");
        spriteList[6] = muiFacade.GetSpriteResource("MachineTabUp.png");
        spriteList[7] = muiFacade.GetSpriteResource("MachineTabDown.png");
        spriteList[8] = muiFacade.GetSpriteResource("FriendTabUp.png");
        spriteList[9] = muiFacade.GetSpriteResource("FriendTabDown.png");
        spriteList[10] = muiFacade.GetSpriteResource("OtherTabUp.png");
        spriteList[11] = muiFacade.GetSpriteResource("OtherTabDown.png");
    }
}
