using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageState : BaseSceneState
{
    public HomePageState(UIFacade uiFacade) : base(uiFacade)
    {

    }

    public override void EnterScene()
    {
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.HomePagePanel);
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.CommonPagePanel);
        mUIFacade.AddUIPanelGameObjectToDic(CommentName.TaskPanel);
        base.EnterScene();
    }

    public override void ExitScene()
    {

        base.ExitScene();
    }
}
