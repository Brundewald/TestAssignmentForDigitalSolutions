using System;
using Assets.Code.Interfaces;
using JetBrains.Annotations;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using UnityEditor;
using UnityEngine;

namespace TestAssingment.Controllers
{
    public sealed class ButtonActionHandler: ICleanup, IDisposable
    {
        private readonly IButtonHandler _menuButtonHandler;
        private readonly GameStateHandler _gameStateHandler;

        public ButtonActionHandler(IButtonHandler menuButtonHandler, GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _menuButtonHandler = menuButtonHandler;
            _menuButtonHandler.OnButtonPressed += ButtonAction;
        }

        public void Cleanup()
        {
            _menuButtonHandler.OnButtonPressed -= ButtonAction;
        }

        public void Dispose()
        {
            _menuButtonHandler.OnButtonPressed -= ButtonAction;
        }

        private void ButtonAction(ButtonTokenEnum buttonPressed)
        {
            if (buttonPressed.Equals(ButtonTokenEnum.Play))
            {
                _gameStateHandler.SwitchState(GameStates.Play);
            }
            else if (buttonPressed.Equals(ButtonTokenEnum.Default))
            {
                _gameStateHandler.SwitchState(GameStates.Default);
            }
            else if (buttonPressed.Equals(ButtonTokenEnum.Exit))
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
        }
    }
}