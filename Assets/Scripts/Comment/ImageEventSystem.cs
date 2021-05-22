using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageEventSystem : IPointerClickHandler
{
    public bool isClick = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        isClick = true;
    }

    public bool GetisClick()
    {
        return isClick;
    }
}
