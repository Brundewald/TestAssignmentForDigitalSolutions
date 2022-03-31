using System;
using Assets.Code.Interfaces;
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

        public event Action<GameStates> OnGameStateChange;
        
        public ButtonActionHandler(IButtonHandler menuButtonHandler)
        {
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
                OnGameStateChange?.Invoke(GameStates.Play);
            }
            else if (buttonPressed.Equals(ButtonTokenEnum.Default))
            {
                OnGameStateChange?.Invoke(GameStates.Default);
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