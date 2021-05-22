using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelRoot : MonoBehaviour
{
    public UIFacade muiFacade;
    public CfgSve cfgsve;
    public int height;
    public int width;
    public RectTransform ScreenSize;
    //初始化
    public virtual void Init(UIFacade mui)
    {
        muiFacade = mui;
        cfgsve = CfgSve.Instance;
        ScreenSize = transform.GetComponent<RectTransform>();
        //ScreenSize.sizeDelta = new Vector2(Screen.width, Screen.height);
        
    }

    //切换显示状态
    public virtual void SetActiveState(bool isTrue = true)
    {
        if (isTrue)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
