using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseResourcesFactory<T> 
{
    T GetSingleResource(string resourcePath);
}
