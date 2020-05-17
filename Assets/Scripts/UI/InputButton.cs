using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public InputType inputType;
    
    public Action<InputType> OnDown;

    public Action<InputType> OnUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown.Invoke(inputType);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp.Invoke(inputType);
    }
}

public enum InputType
{
    left,
    right
}
