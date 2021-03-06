using System;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.Controllers
{
    public sealed class PlayerInputHandler: IButtonHandler, IExecute, IDisposable, ICleanup
    {
        private readonly Camera _arCamera;
        private Button _exitButton;
        private Button _sellButton;
        private Button _mixButton;
        private Button _emptyVileButton;

        public event Action OnButtonSellPressed;
        public event Action OnMixButtonPressed;
        public event Action OnEmptyVilePressed;
        public event Action<ButtonTokenEnum> OnButtonPressed;
        public event Action<GameObject> OnElementFound;

        public PlayerInputHandler(ReferenceHolder referenceHolder, HUDInitializer hudInitializer)
        {
            _arCamera = referenceHolder.ARCamera;
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
            if (Input.touchCount > 0)
            {
                for (var i = 0; i < Input.touchCount; i++)
                {
                    var touch = Input.GetTouch(i);
                    if(touch.phase != TouchPhase.Began) return;
                    var touchPosition = touch.position;

                    var ray = _arCamera.ScreenPointToRay(touchPosition);
                    Physics.Raycast(ray, out var raycastHit);
                    
                    if(raycastHit.collider != null)
                        OnElementFound?.Invoke(raycastHit.collider.gameObject);
                }
            }
        }
    }
}