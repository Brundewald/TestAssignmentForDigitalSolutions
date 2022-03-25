using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.View
{
    public sealed class GameHUDView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreField;
        [SerializeField] private Transform _firstElementParent;
        [SerializeField] private Transform _secondElementParent;
        [SerializeField] private Transform _resultElementParent;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _exitToMainMenuButton;
        [SerializeField] private Button _mixButton;
        [SerializeField] private Camera _cameraHUD;

        public TextMeshProUGUI ScoreField => _scoreField;
        public Transform FirstElementParent => _firstElementParent;
        public Transform SecondElementParent => _secondElementParent;
        public Transform ResultElementParent => _resultElementParent;
        public Button SellButton => _sellButton;
        public Button ExitToMainMenuButton => _exitToMainMenuButton;
        public Button MixButton => _mixButton;
        public Camera CameraHUD => _cameraHUD;
        
    }
}
