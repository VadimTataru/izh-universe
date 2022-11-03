﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UIScreenStateEnum = UIScreenStateClass.UIScreenStateEnum;
using ButtonPurposeState = ButtonPurpose.ButtonPurposeState;

namespace DefaultNamespace
{
    
    /// <summary>
    /// сделать ивенты для события нажатия
    /// StateMachine подписываеться на событие каждой кнопки
    /// кнопка может как передавать 2 стейта, так и не передавать стеейты вовсе
    /// </summary>
    public class ButtonHandler : MonoBehaviour
    {
        public event Action<UIScreenStateEnum, UIScreenStateEnum, ButtonPurposeState> OnButtonClick;
        
        [SerializeField] private UIScreenStateEnum currentState;
        [SerializeField] private UIScreenStateEnum nextState;
        [SerializeField] private ButtonPurposeState buttonPurposeState;
        [SerializeField] private Button thisButton;

        private void Start()
        {
            thisButton.onClick.AddListener(OnClick);
        }

        void OnClick() => OnButtonClick?.Invoke(currentState, nextState, buttonPurposeState);
    }
}

[Serializable]
public class ButtonPurpose
{
    [Serializable]
    public enum ButtonPurposeState
    {
        Next,
        Back,
        None
    }
}