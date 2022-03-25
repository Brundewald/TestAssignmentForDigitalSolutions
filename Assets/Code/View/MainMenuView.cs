using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.View
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        public Button PlayButton => _playButton;
        public Button ExitButton => _exitButton;
    }   
}
