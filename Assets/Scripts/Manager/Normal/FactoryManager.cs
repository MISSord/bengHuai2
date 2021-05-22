using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager 
{
    public GameRoot gameRoot;
    public Dictionary<FactoryType, BaseFactory> factoryDic = new Dictionary<FactoryType, BaseFactory>();
    public SpriteFactory spriteFactory;

    public FactoryManager()
    {
        factoryDic.Add(FactoryType.UIPanelFactory, new UIPanelFactory());
        factoryDic.Add(FactoryType.UIFactory, new UIFactory());
        factoryDic.Add(FactoryType.GameObjectFactory, new GOFactory());

        spriteFactory = new SpriteFactory();
    }
}

public enum FactoryType
{
    UIPanelFactory,
    UIFactory,
    GameObjectFactory
}
