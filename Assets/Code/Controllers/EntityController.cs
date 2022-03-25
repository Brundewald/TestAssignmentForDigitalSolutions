using TestAssingment.Enum;
using TestAssingment.Interfaces;
using TestAssingment.View;

namespace TestAssingment.Controllers
{
    public sealed class EntityController
    {
        private readonly ControllersProxy _controllers;
        private readonly ReferenceHolder _prefabesReferenceHolder;
        private readonly DefaultStateBoot _defaultStateBoot;
        private readonly PlayStateBoot _playStateBoot;
        private readonly GameStateHandler _gameStateHandler;
        private IGameState _activeState;

        public EntityController(ControllersProxy controllers,
            ReferenceHolder referenceHolder)
        {
            _gameStateHandler = new GameStateHandler();
            _defaultStateBoot = new DefaultStateBoot(_gameStateHandler, controllers, referenceHolder);
            _playStateBoot = new PlayStateBoot(_gameStateHandler, controllers, referenceHolder);
        }

        public void Init()
        {
            _gameStateHandler.OnStateChange += ChangeState;
            _gameStateHandler.SwitchState(GameStates.Default);
        }

        public void Clean()
        {
            _gameStateHandler.OnStateChange -= ChangeState;
        }
        
        private void ChangeState(GameStates gameStates)
        {
            switch (gameStates)
            {
                case GameStates.Default:
                    SwitchState(_defaultStateBoot);
                    break;
                case GameStates.Play:
                    SwitchState(_playStateBoot);
                    break;
            }
        }

        private void SwitchState(IGameState gameStateToEnter)
        {
            _activeState?.ExitState();
            _activeState = gameStateToEnter;
            _activeState.EnterState();
        }
    }
}