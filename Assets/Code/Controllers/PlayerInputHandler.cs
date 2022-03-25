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
        private Button _emptyVileButton;

        public event Action OnButtonSellPressed;
        public event Action OnMixButtonPressed;
        public event Action OnEmptyVilePressed;
        public event Action<ButtonTokenEnum> OnButtonPressed;
        public event Action<int> OnElementFound;

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
            _emptyVileButton = hudInitializer.EmptyVileButton;
        }

        private void SubscribeEvents()
        {
            _exitButton.onClick.AddListener(ExitButtonPressed);
            _sellButton.onClick.AddListener(SellButtonPressed);
            _mixButton.onClick.AddListener(MixButtonPressed);
            _emptyVileButton.onClick.AddListener(EmptyVile);
        }

        private void UnsubscribeEvents()
        {
            _exitButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
            _mixButton.onClick.RemoveAllListeners();
            _emptyVileButton.onClick.RemoveAllListeners();
        }

        private void EmptyVile()
        {
            OnEmptyVilePressed?.Invoke();
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
            var getKey1 = Input.GetKeyDown(KeyCode.Keypad1)||Input.GetKeyDown(KeyCode.Alpha1);
            var getKey2 = Input.GetKeyDown(KeyCode.Keypad2)||Input.GetKeyDown(KeyCode.Alpha2);
            var getKey3 = Input.GetKeyDown(KeyCode.Keypad3)||Input.GetKeyDown(KeyCode.Alpha3);
            var getEsc = Input.GetButtonDown(ButtonNames.Cancel);
            
            if (getEsc) 
                OnButtonPressed?.Invoke(ButtonTokenEnum.Default);
            if (getKey1)
                OnElementFound?.Invoke(0);
            if (getKey2)
                OnElementFound?.Invoke(1);
            if (getKey3)
                OnElementFound?.Invoke(2);
        }
    }
}