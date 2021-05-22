using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFactory 
{
    //当前拥有的gameobject类型的资源(UI,UIPanel，Game)  切记：它存放的是游戏物体资源
    protected Dictionary<string, GameObject> factoryDict = new Dictionary<string, GameObject>();
    //对象池字典
    protected Dictionary<string, Stack<GameObject>> objectPoolDict = new Dictionary<string, Stack<GameObject>>();
    //对象池（就是我们具体存储的游戏物体类型的对象）注：对应的是一个具体的游戏物体对象

    protected string LoadPath;

    public BaseFactory()
    {
        LoadPath = "Prefab/";
    }

    //获取资源
    public GameObject GetResource(string path)
    {
        GameObject itemGo = null;
        string FinalLoadPath = LoadPath + path;
        if (factoryDict.ContainsKey(FinalLoadPath))
        {
            itemGo = factoryDict[FinalLoadPath];
        }
        else
        {
            itemGo = Resources.Load<GameObject>(FinalLoadPath);
            factoryDict.Add(FinalLoadPath, itemGo);
        }
        if (itemGo == null)
        {
            Debug.Log(path + "的资源获取失败了");
            Debug.Log("失败路径：" + FinalLoadPath);
        }

        return itemGo;
    }

    /// <summary>
    /// 获取游戏物体并且实例化返回
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string path)
    {
        GameObject itemGo = null;
        if (objectPoolDict.ContainsKey(path))
        {
            if (objectPoolDict[path].Count == 0)
            {
                itemGo = returnGameObject(path);
            }
            else
            {
                itemGo = objectPoolDict[path].Pop();
                //itemGo.SetActive(true);
            }
        }
        else
        {
            objectPoolDict.Add(path, new Stack<GameObject>());
            itemGo = returnGameObject(path);
            
        }
        if(itemGo == null)
        {
            Debug.Log(path + "的实例获取失败");
        }
        return itemGo;
    }

    public GameObject returnGameObject(string path)
    {
        GameObject item = GetResource(path);
        Debug.Log(path);
        if (path.Contains("Panel"))
        {
            item = GameRoot.Instance.GetUIPanelItem(item);
        }
        else
        {
            item = GameRoot.Instance.CreateItem(item);
        }
        return item;
    }

    /// <summary>
    /// 回收到对象栈
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="item"></param>
    public void PushToObjectPanel(string Name, GameObject item)
    {
        item.SetActive(false);
        item.transform.SetParent(GameRoot.Instance.GameObjectPoolCanvas.transform);
        if (objectPoolDict.ContainsKey(Name))
        {
            objectPoolDict[Name].Push(item);
        }
        else
        {
            Debug.Log("当前字典没有" + Name + "的栈");
        }
    }
}
