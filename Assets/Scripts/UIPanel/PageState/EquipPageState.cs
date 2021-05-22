using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPageState : BaseSceneState
{
    public EquipPageState(UIFacade uiFacade) : base(uiFacade)
    {
    }

    public override void EnterScene()
    {
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.EquipPagePanel);
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.CommonPagePanel);
        base.EnterScene();
    }
}
