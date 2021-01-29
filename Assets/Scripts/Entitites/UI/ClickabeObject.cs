using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickabeObject : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;
    public UnityEvent onMiddleClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            onLeftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            onRightClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            onMiddleClick.Invoke();
    }
}
