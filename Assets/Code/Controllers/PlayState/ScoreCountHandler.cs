using System;
using TestAssingment.Enum;
using TestAssingment.Interfaces;
using TestAssingment.View;
using TMPro;

namespace TestAssingment.Controllers
{
    public sealed class ScoreCountHandler: ICleanup, IDisposable
    {
        private const string Message = "Reward: ";
        private readonly ElementHandler _elementHandler;
        private readonly TextMeshProUGUI _scoreHolder;
        private readonly int _winScore;
        private float _score;

        public event Action<GameStates> OnWinScoreEarned;
        
        public ScoreCountHandler(HUDInitializer hudInitializer, ReferenceHolder referenceHolder, ElementHandler elementHandler)
        {
            _scoreHolder = hudInitializer.ScoreHolder;
            _scoreHolder.text = Message;
            _elementHandler = elementHandler;
            _winScore = referenceHolder.GameSettings.WinScore;
            _elementHandler.OnResultSold += AddScore;
        }

        public void Dispose()
        {
            _elementHandler.OnResultSold -= AddScore;
        }

        public void Cleanup()
        {
            _elementHandler.OnResultSold -= AddScore;
        }

        private void AddScore(float score)
        {
            _score += score;
            _scoreHolder.text = Message + _score;
            CheckScore();
        }

        private void CheckScore()
        {
            if(_score >= _winScore)
                OnWinScoreEarned?.Invoke(GameStates.Win);
        }
    }
}