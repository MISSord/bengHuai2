using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;
public class CfgSve 
{
    private static CfgSve instance = null;

    public static CfgSve Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CfgSve();
            }
            return instance;
        }
    }

    public void Init()
    {
        //InitTaskCfg(PathDefine.TaskCfg);
        Debug.Log("配置文件获取完成");
    }

    private Dictionary<int, TaskRewardCfg> TaskRewardDic = new Dictionary<int, TaskRewardCfg>();

    public void InitTaskCfg(string path)
    {
        if (!File.Exists(path))
        {
            Debug.Log("文件不存在，路径" + path);
            return;
        }
        TextAsset xml = Resources.Load<TextAsset>(path);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml.text);

        XmlNodeList nodList = doc.SelectSingleNode("root").ChildNodes;

        for(int i = 0; i < nodList.Count; i++)
        {
            XmlElement ele = nodList[i] as XmlElement;
            if (ele.GetAttributeNode("ID") == null)
            {
                Debug.Log("信息为空");
                continue;
            }
            int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
            TaskRewardCfg trc = new TaskRewardCfg
            {
                ID = ID,
            };

            foreach (XmlElement e in nodList[i].ChildNodes)
            {
                switch (e.Name)
                {
                    case "taskName":
                        trc.taskName = e.InnerText;
                        break;
                    case "count":
                        trc.count = int.Parse(e.InnerText);
                        break;
                    case "exp":
                        trc.exp = int.Parse(e.InnerText);
                        break;
                    case "coin":
                        trc.coin = int.Parse(e.InnerText);
                        break;
                }
            }

            TaskRewardDic.Add(ID, trc);
        }
    }

}
