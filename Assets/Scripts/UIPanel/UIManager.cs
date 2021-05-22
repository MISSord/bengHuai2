using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    private static UIManager instance;
    public UIFacade uiFacade;
    public Dictionary<string, GameObject> currentUIPanelDict = new Dictionary<string, GameObject>();
    //public Stack<GameObject> UIPanelSta = new Stack<GameObject>();

    public int ScreenHeight;
    public int ScreenWidth;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    public UIManager()
    {
        ScreenHeight = Screen.height;
        ScreenWidth = Screen.width;
        instance = this;
        uiFacade = new UIFacade(this);
    }

    //清空字典
    public void ClearDic()
    {
        foreach (var item in currentUIPanelDict)
        {
            GameRoot.Instance.PushToObjectPool(FactoryType.UIPanelFactory,
                item.Value.name.Substring(0, item.Value.name.Length - 7), item.Value.gameObject);
        }
        currentUIPanelDict.Clear();
    }

}
