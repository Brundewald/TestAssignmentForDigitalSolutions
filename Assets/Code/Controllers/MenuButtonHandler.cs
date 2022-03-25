using System;
using Assets.Code.Interfaces;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine.UI;

namespace TestAssingment.Controllers
{
    public sealed class MenuButtonHandler: IButtonHandler, ICleanup, IDisposable
    {
        private Button _playButton;
        private Button _exitButton;

        public event Action<ButtonTokenEnum> OnButtonPressed;

        public MenuButtonHandler(MainMenuView mainMenuView)
        {
            GetButtons(mainMenuView);
            SubscribeEvents();
        }

        public void Cleanup()
        {
            UnsubscribeEvents();
        }

        public void Dispose()
        {
            UnsubscribeEvents();
        }

        private void PlayPressed()
        {
            OnButtonPressed?.Invoke(ButtonTokenEnum.Play);
        }

        private void ExitPressed()
        {
            OnButtonPressed?.Invoke(ButtonTokenEnum.Exit);
        }

        private void UnsubscribeEvents()
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void SubscribeEvents()
        {
            _playButton.onClick.AddListener(PlayPressed);
            _exitButton.onClick.AddListener(ExitPressed);
        }

        private void GetButtons(MainMenuView mainMenuView)
        {
            _playButton = mainMenuView.PlayButton;
            _exitButton = mainMenuView.ExitButton;
        }
    }
}