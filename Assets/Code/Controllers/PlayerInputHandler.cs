using System;
using Assets.Code.Interfaces;
using TestAssingment.Data;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.Controllers
{
    public class PlayerInputHandler: IButtonHandler, IExecute, IDisposable, ICleanup
    {
        private Button _exitButton;
        private Button _sellButton;
        private Button _mixButton;

        public event Action OnButtonSellPressed;
        public event Action OnMixButtonPressed;
        public event Action<ButtonTokenEnum> OnButtonPressed;
        public event Action<KeyCode> OnElementFound;

        public PlayerInputHandler(HUDInitializer hudInitializer)
        {
            GetButtons(hudInitializer);
            SubscribeEvents();
        }

        public void Dispose()
        {
            UnsubscribeEvents();
        }

        public void Cleanup()
        {
            UnsubscribeEvents();
        }

        private void GetButtons(HUDInitializer hudInitializer)
        {
            _exitButton = hudInitializer.ExitToMainMenuButton;
            _sellButton = hudInitializer.SellButton;
            _mixButton = hudInitializer.MixButton;
        }

        private void SubscribeEvents()
        {
            _exitButton.onClick.AddListener(ExitButtonPressed);
            _sellButton.onClick.AddListener(SellButtonPressed);
            _mixButton.onClick.AddListener(MixButtonPressed);
        }

        private void UnsubscribeEvents()
        {
            _exitButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
            _mixButton.onClick.RemoveAllListeners();
        }

        private void MixButtonPressed()
        {
            OnMixButtonPressed?.Invoke();
        }

        private void SellButtonPressed()
        {
            OnButtonSellPressed?.Invoke();
        }

        private void ExitButtonPressed()
        {
            OnButtonPressed?.Invoke(ButtonTokenEnum.Default);
        }

        public void Execute(float deltaTime)
        {
            KeysHandle();
        }
        
        private void KeysHandle()
        {
            var getKeyA = Input.GetKeyDown(KeyCode.A);
            var getKeyS = Input.GetKeyDown(KeyCode.S);
            var getEsc = Input.GetButtonDown(ButtonNames.Cancel);
            if (getEsc) 
                OnButtonPressed?.Invoke(ButtonTokenEnum.Default);
            if (getKeyA)
                OnElementFound?.Invoke(KeyCode.A);
            if (getKeyS)
                OnElementFound?.Invoke(KeyCode.S);
        }
    }
}