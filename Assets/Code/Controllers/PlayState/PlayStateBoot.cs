using TestAssingment.Interfaces;
using TestAssingment.View;

namespace TestAssingment.Controllers
{
    public sealed class PlayStateBoot: IGameState
    {
        private readonly GameStateHandler _gameStateHandler;
        private readonly ControllersProxy _controllers;
        private readonly ReferenceHolder _referenceHolder;
        public PlayStateBoot(GameStateHandler gameStateHandler, ControllersProxy controllers, ReferenceHolder referenceHolder)
        {
            _gameStateHandler = gameStateHandler;
            _controllers = controllers;
            _referenceHolder = referenceHolder;
        }

        public void EnterState()
        {
            var switchGameStateHandler = new SwitchGameStateEventHandler(_gameStateHandler);
            var hudInitializer = new HUDInitializer(_referenceHolder);
            var playerInputHandler = new PlayerInputHandler(_referenceHolder,hudInitializer);
            var buttonActionHandler = new ButtonActionHandler(playerInputHandler);
            var imageTrackingHandler = new ImageTrackingHandler(_referenceHolder);
            var elementHandler = new ElementHandler(_referenceHolder, hudInitializer, playerInputHandler, imageTrackingHandler);
            var scoreCountHolder = new ScoreCountHandler(hudInitializer, _referenceHolder, elementHandler);
            
            _controllers.Add(hudInitializer);
            _controllers.Add(playerInputHandler);
            _controllers.Add(buttonActionHandler);
            _controllers.Add(imageTrackingHandler);
            _controllers.Add(elementHandler);
            _controllers.Add(scoreCountHolder);
            
            scoreCountHolder.OnWinScoreEarned += switchGameStateHandler.SwitchState;
            buttonActionHandler.OnGameStateChange += switchGameStateHandler.SwitchState;
        }

        public void ExitState()
        {
            _controllers.Dispose();
            _controllers.Clear();
        }
    }
}