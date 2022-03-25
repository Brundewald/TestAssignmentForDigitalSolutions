using System;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using TestAssingment.View;

namespace TestAssingment.Controllers
{
    public sealed class DefaultStateBoot: IGameState
    {
        private readonly ControllersProxy _controllers;
        private readonly GameStateHandler _gameStateHandler;
        private readonly ReferenceHolder _referenceHolder;
        private MenuButtonHandler _menuButtonHandler;
        private ButtonActionHandler _buttonActionHandler;
        private MainMenuInitialization _mainMenuInitialization;

        public event Action<ButtonTokenEnum> OnButtonPressed;
        
        public DefaultStateBoot(GameStateHandler gameStateHandler, ControllersProxy controllersProxy, ReferenceHolder referenceHolder)
        {
            _gameStateHandler = gameStateHandler;
            _controllers = controllersProxy;
            _referenceHolder = referenceHolder;
        }

        public void EnterState()
        {
            _mainMenuInitialization = new MainMenuInitialization(_referenceHolder.MainMenuPrefab);
            _menuButtonHandler = new MenuButtonHandler(_mainMenuInitialization.MainMenuView);
            _buttonActionHandler = new ButtonActionHandler(_menuButtonHandler, _gameStateHandler);
            _controllers.Add(_mainMenuInitialization);
            _controllers.Add(_menuButtonHandler);
            _controllers.Add(_buttonActionHandler);
        }

        public void ExitState()
        {
            _controllers.Dispose();
        }
    }
}