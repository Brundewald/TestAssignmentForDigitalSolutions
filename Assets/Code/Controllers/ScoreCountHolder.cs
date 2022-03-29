using System;
using TestAssingment.Interfaces;
using TMPro;

namespace TestAssingment.Controllers
{
    public class ScoreCountHolder: ICleanup, IDisposable
    {
        private const string Message = "Reward: ";
        private readonly ElementHandler _elementHandler;
        private readonly TextMeshProUGUI _scoreHolder;
        private float _score;

        public ScoreCountHolder(HUDInitializer hudInitializer, ElementHandler elementHandler)
        {
            _scoreHolder = hudInitializer.ScoreHolder;
            _scoreHolder.text = Message;
            _elementHandler = elementHandler;
            _elementHandler.OnResultSold += ShowScore;
        }

        private void ShowScore(float score)
        {
            _score += score;
            _scoreHolder.text = Message + _score;
        }

        public void Dispose()
        {
            _elementHandler.OnResultSold -= ShowScore;
        }

        public void Cleanup()
        {
            _elementHandler.OnResultSold -= ShowScore;
        }
    }
}