using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSceneState 
{
    protected UIFacade mUIFacade;

    public BaseSceneState(UIFacade uiFacade)
    {
        mUIFacade = uiFacade;
    }

    //初始化
    public virtual void InitScene()
    {

    }

    //进入
    public virtual void EnterScene()
    {
        InitScene();
        mUIFacade.InitDict();
    }
    
    //离开
    public virtual void ExitScene()
    {
        mUIFacade.ClearDict();
    }

    //更新
    public virtual void UpdateScene()
    {

    }

}
