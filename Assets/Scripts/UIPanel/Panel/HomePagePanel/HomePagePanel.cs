using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HomePagePanel : UIPanelRoot
{
    public Button btn_Procl;
    public Button btn_Task;
    public Button btn_Act;

    //public 

    public override void Init(UIFacade mui)
    {
        base.Init(mui);
        btn_Procl = transform.GetChild(1).Find("Btn_Procl").GetComponent<Button>();
        btn_Task = transform.GetChild(1).Find("Btn_Task").GetComponent<Button>();
        btn_Task.onClick.AddListener(() => {
            muiFacade.ToNextPanel(muiFacade.GetUIPanelInstance("TaskPanel"));
        });
        btn_Act = transform.GetChild(2).Find("Btn_Act").GetComponent<Button>();
        SetActiveState(true);
    }

    public void OpenTaskPanel()
    {
        
    }


}
