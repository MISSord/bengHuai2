using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏物体加载工厂
/// </summary>
public class GOFactory : BaseFactory
{
    public GOFactory()
    {
        LoadPath += "Game/";
    }
}
