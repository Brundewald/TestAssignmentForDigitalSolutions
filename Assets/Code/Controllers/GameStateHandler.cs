using System;
using TestAssingment.Enum;

namespace TestAssingment.Controllers
{
    public sealed class GameStateHandler
    {
        public event Action<GameStates> OnStateChange;
        
        public void SwitchState(GameStates gameStates)
        {
            switch (gameStates)
            {
                case GameStates.Default:
                case GameStates.Settings:
                case GameStates.Play:
                case GameStates.Pause:
                    OnStateChange?.Invoke(gameStates);
                    break;
            }
        }
    }
}