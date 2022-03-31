using TestAssingment.Interfaces;
using TestAssingment.View;

namespace TestAssingment.Controllers
{
    public sealed class WinStateBoot: IGameState
    {
        private readonly GameStateHandler _gameStatesHandler;
        private readonly ControllersProxy _controllers;
        private readonly ReferenceHolder _referenceHolder;

        public WinStateBoot(GameStateHandler gameStateHandler, ControllersProxy controllersProxy, ReferenceHolder referenceHolder)
        {
            _gameStatesHandler = gameStateHandler;
            _controllers = controllersProxy;
            _referenceHolder = referenceHolder;
        }

        public void EnterState()
        {
            var switchGameStateEventHandler = new SwitchGameStateEventHandler(_gameStatesHandler);
            var winMenuInitialization = new WinMenuInitializations(_referenceHolder);
            var menuButtonHandler = new MenuButtonHandler(winMenuInitialization.WinMenuView);
            var buttonActionHandler = new ButtonActionHandler(menuButtonHandler);
            _controllers.Add(winMenuInitialization);
            _controllers.Add(menuButtonHandler);
            _controllers.Add(buttonActionHandler);
            buttonActionHandler.OnGameStateChange += switchGameStateEventHandler.SwitchState;
        }

        public void ExitState()
        {
            _controllers.Dispose();
            _controllers.Clear();
        }
    }
}