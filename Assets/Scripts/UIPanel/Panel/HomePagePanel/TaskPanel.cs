using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : UIPanelRoot
{
    public Transform contentTran;
    public Button btnReturn;

    public override void Init(UIFacade mui)
    {
        base.Init(mui);
        //contentTran = transform.Find("Content");
        btnReturn = transform.Find("Btn_Return").GetComponent<Button>();
        btnReturn.onClick.AddListener(()=> {
            SetActiveState(false);
        });
        RefreshTask();
    }

    public void RefreshTask()
    {
        for(int i = 0; i < 6; i++)
        {
            GameObject item = muiFacade.GetUI(CommentName.TaskItem);
            item.transform.SetParent(contentTran);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;
        }
    }
    
}
