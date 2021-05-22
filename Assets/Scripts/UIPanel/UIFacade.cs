using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacade 
{
    public UIManager uiManager;
    public GameRoot mGameRoot;
    public Dictionary<string, UIPanelRoot> currentUIPanelDict = new Dictionary<string, UIPanelRoot>();
    public BaseSceneState currentScene;
    public BaseSceneState LastScene;
    public Transform CanvasTran;
    public SpriteRenderer BG_Sprite;
    public UIPanelRoot nextPanel;

    public UIFacade(UIManager uiM)
    {
        uiManager = uiM;
        mGameRoot = GameRoot.Instance;
        CanvasTran = GameObject.Find("Canvas").transform;
        Init();
    }

    //初始化
    public void Init()
    {
        BG_Sprite = GameObject.Find("BG").GetComponent<SpriteRenderer>();
        AddUIPanelGameObjectToDic(CommentName.StartLoadGamePanel);
        InitDict();
    }

    //初始化各面板
    public void InitDict()
    {
        foreach(var item in uiManager.currentUIPanelDict)
        {
            item.Value.transform.SetParent(CanvasTran);
            //item.Value.transform.localPosition = Vector3.zero;
            item.Value.transform.localScale = Vector3.one;
            UIPanelRoot uiPanel = item.Value.transform.GetComponent<UIPanelRoot>();
            if(uiPanel == null)
            {
                Debug.Log("获取UIPanelRoot失败");
                continue;
            }
            uiPanel.SetActiveState(false);
            uiPanel.Init(this);
            
            currentUIPanelDict.Add(item.Key, uiPanel);
        }
        SetBGSize();
    }

    public void ClearDict()
    {
        currentUIPanelDict.Clear();
    }

    public void EnterNextScene()
    {
        if(LastScene != null)
        {
            LastScene.ExitScene();
        }
        uiManager.ClearDic();
        ClearDict();
        currentScene.EnterScene();
    }

    public void ChangeSceneState(BaseSceneState current)
    {
        LastScene = currentScene;
        currentScene = current;
        EnterNextScene();
    }

    public void AddUIPanelGameObjectToDic(string name)
    {
        uiManager.currentUIPanelDict.Add(name,mGameRoot.GetUIPanelFromFactory(name));
    }

    public void SetBGSize()
    {
        Sprite bg = mGameRoot.GetSpriteFromFactory("BackGround/BG_1");
        float finalSize = 0;
        if(Screen.width > bg.rect.width)
        {
            finalSize = Screen.width / bg.rect.width;           
        }
        else
        {
            finalSize = bg.rect.width / Screen.width;
        }
        BG_Sprite.transform.localScale = new Vector3(finalSize, finalSize, finalSize);
        BG_Sprite.sprite = bg;
        
    }

    public Sprite GetSpriteResource(string path)
    {
        string pathone = "";
        if (currentScene.GetType() == typeof(HomePageState))
        {
            pathone = "CommonPanel/";
            pathone += path;
        }
        return mGameRoot.GetSpriteFromFactory(pathone);
    }

    public GameObject GetGameObject(string path)
    {
        return mGameRoot.GetGameObjectFromFactory(path);
    }

    public GameObject GetUIPanel(string path)
    {
        return mGameRoot.GetUIPanelFromFactory(path);
    }

    public GameObject GetUI(string path)
    {
        return mGameRoot.GetUIFromFactory(path);
    }

    public void ToNextPanel(UIPanelRoot uiPanel)
    {
        nextPanel = uiPanel;
        nextPanel.SetActiveState();

    }

    public UIPanelRoot GetUIPanelInstance(string name)
    {
        UIPanelRoot item = null;
        if (currentUIPanelDict.TryGetValue(name, out item))
        {
            return item;
        }
        else
        {
            Debug.Log("获取UIPanelRoot失败");
        }
        return null;
    }
}
