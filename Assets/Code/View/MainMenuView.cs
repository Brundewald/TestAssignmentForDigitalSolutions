using Assets.Code.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.View
{
    public sealed class MainMenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Canvas _canvas;

        public Button PlayButton => _playButton;
        public Button ExitButton => _exitButton;
        public Canvas Canvas => _canvas;
    }   
}
