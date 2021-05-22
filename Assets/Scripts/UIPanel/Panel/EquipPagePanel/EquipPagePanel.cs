using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipPagePanel : UIPanelRoot
{
    public Button[] btns;

    public override void Init(UIFacade mui)
    {
        SetActiveState(true);
        base.Init(mui);
        btns = transform.Find("RightPart").GetComponentsInChildren<Button>();
    }

    public void SetOnclick()
    {
        //btns[0].onClick.AddListener()
    }
}
