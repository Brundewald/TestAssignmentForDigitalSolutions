using TestAssingment.Enum;

namespace TestAssingment.Controllers
{
    public sealed class SwitchGameStateEventHandler
    {
        private readonly GameStateHandler _gameStateHandler;

        public SwitchGameStateEventHandler(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
        }

        public void SwitchState(GameStates gameStates)
        {
            _gameStateHandler.SwitchState(gameStates);
        }
    }
}