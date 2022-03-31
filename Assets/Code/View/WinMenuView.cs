using Assets.Code.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.View
{
    public sealed class WinMenuView: MonoBehaviour, IMenuView
    {
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _toMainMenuButton;

        public Button PlayButton => _playAgainButton;
        public Button ExitButton => _toMainMenuButton;
    }
}