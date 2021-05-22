using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRoot:MonoBehaviour
{
    private static GameRoot instance = null;
    public GameObject GameObjectPool;//对象池
    public GameObject GameObjectPoolCanvas;

    public FactoryManager mfactoryManager;
    public UIManager uiManager;
    public CfgSve cfgsve;

    public Transform CanvasTrans;


    public static GameRoot Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        GameObjectPool = transform.Find("GameObjectPool").gameObject;
        GameObjectPoolCanvas = transform.Find("GameObjectPool").Find("GameObjectPoolCanvas").gameObject;
        CanvasTrans = GameObject.Find("Canvas").transform;

        cfgsve = CfgSve.Instance;
        mfactoryManager = new FactoryManager();
        uiManager = new UIManager();
        
        


        
    }

    public GameObject CreateItem(GameObject item)
    {
        GameObject go = Instantiate(item);
        return go;
    }

    public GameObject GetUIPanelItem(GameObject item)
    {
        GameObject go = Instantiate(item,CanvasTrans);
        return go;
    }

    public GameObject GetGameObjectFromFactory(string path)
    {
        return mfactoryManager.factoryDic[FactoryType.GameObjectFactory].GetGameObject(path);
    }
    public GameObject GetUIFromFactory(string path)
    {
        return mfactoryManager.factoryDic[FactoryType.UIFactory].GetGameObject(path);
    }
    public GameObject GetUIPanelFromFactory(string path)
    {
        return mfactoryManager.factoryDic[FactoryType.UIPanelFactory].GetGameObject(path);
    }
    public Sprite GetSpriteFromFactory(string path)
    {
        return mfactoryManager.spriteFactory.GetSingleResource(path);
    }

    public void PushToObjectPool(FactoryType factoryType, string resourcePath,GameObject item)
    {
        mfactoryManager.factoryDic[factoryType].PushToObjectPanel(resourcePath,item);
    }

    


}
