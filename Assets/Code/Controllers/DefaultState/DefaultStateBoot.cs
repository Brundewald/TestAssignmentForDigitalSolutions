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
        
        public DefaultStateBoot(GameStateHandler gameStateHandler, ControllersProxy controllersProxy, ReferenceHolder referenceHolder)
        {
            _gameStateHandler = gameStateHandler;
            _controllers = controllersProxy;
            _referenceHolder = referenceHolder;
        }

        public void EnterState()
        {
            var switchGameStateHandler = new SwitchGameStateEventHandler(_gameStateHandler);
            var mainMenuInitialization = new MainMenuInitialization(_referenceHolder.MainMenuPrefab);
            var menuButtonHandler = new MenuButtonHandler(mainMenuInitialization.MainMenuView);
            var buttonActionHandler = new ButtonActionHandler(menuButtonHandler);
            _controllers.Add(mainMenuInitialization);
            _controllers.Add(menuButtonHandler);
            _controllers.Add(buttonActionHandler);
            buttonActionHandler.OnGameStateChange += switchGameStateHandler.SwitchState;
        }

        public void ExitState()
        {
            _controllers.Dispose();
            _controllers.Clear();
        }
    }
}