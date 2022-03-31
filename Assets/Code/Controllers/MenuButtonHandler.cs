using System;
using Assets.Code.Interfaces;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using UnityEngine.UI;

namespace TestAssingment.Controllers
{
    public sealed class MenuButtonHandler: IButtonHandler, ICleanup, IDisposable
    {
        private Button _playButton;
        private Button _exitButton;

        public event Action<ButtonTokenEnum> OnButtonPressed;

        public MenuButtonHandler(IMenuView menuView)
        {
            GetButtons(menuView);
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

        private void GetButtons(IMenuView menuView)
        {
            _playButton = menuView.PlayButton;
            _exitButton = menuView.ExitButton;
        }
    }
}