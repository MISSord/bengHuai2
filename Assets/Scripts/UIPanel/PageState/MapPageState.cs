using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPageState : BaseSceneState
{
    public MapPageState(UIFacade uiFacade) : base(uiFacade)
    {
    }

    public override void EnterScene()
    {
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.CommonPagePanel);

        base.EnterScene();

    }
}
