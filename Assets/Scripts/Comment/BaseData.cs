using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData<T> 
{
    public int ID;
}

public class TaskRewardCfg : BaseData<TaskRewardCfg>
{
    public string taskName;
    public int count;
    public int exp;
    public int coin;
}

public class TaskRewardDate : BaseData<TaskRewardDate>
{
    public int prgs;
    public bool taked;
}

public class PlayerData
{
    public string name;
    public int exp;
    public int lv;
    public int Diamond;
    public int coin;
    public int power;
    public Equipment[] Equipments;
    public string[] taskArr;

}

public class Equipment
{
    public int lv;
    public int attack;
    public int amm;//弹药
    public element elms;
    public string descOne;
    public string descTwo;
}

public enum element
{
    energy,
    five,
    ice,
    physical,
    poison,

}