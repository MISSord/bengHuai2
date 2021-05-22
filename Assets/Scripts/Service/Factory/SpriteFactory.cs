using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFactory : IBaseResourcesFactory<Sprite>
{
    protected Dictionary<string, Sprite> factoryDict = new Dictionary<string, Sprite>();
    protected string LoadPath;

    public SpriteFactory()
    {
        LoadPath = "Sprite/";
    }
    public Sprite GetSingleResource(string resourcePath)
    {
        Sprite itemGo = null;
        string itemLoadPath = LoadPath + resourcePath;
        if (factoryDict.ContainsKey(resourcePath))
        {
            itemGo = factoryDict[resourcePath];
        }
        else
        {
            itemGo = Resources.Load<Sprite>(itemLoadPath);
            factoryDict.Add(resourcePath, itemGo);
        }
        if (itemGo == null)
        {
            Debug.Log(resourcePath + "的资源获取失败");
            Debug.Log("失败路径为" + itemLoadPath);
        }

        return itemGo;
    }
}
