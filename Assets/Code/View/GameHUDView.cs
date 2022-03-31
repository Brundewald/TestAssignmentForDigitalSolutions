using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace TestAssingment.View
{
    public sealed class GameHUDView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreField;
        [SerializeField] private TextMeshProUGUI _objectiveField;
        [SerializeField] private Image _firstElementParent;
        [SerializeField] private Image _secondElementParent;
        [SerializeField] private Image _resultElementParent;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _exitToMainMenuButton;
        [SerializeField] private Button _mixButton;
        [SerializeField] private Button _emptyVileButton;

        public TextMeshProUGUI ScoreField => _scoreField;
        public TextMeshProUGUI ObjectiveField => _objectiveField;
        public Image FirstElementParent => _firstElementParent;
        public Image SecondElementParent => _secondElementParent;
        public Image ResultElementParent => _resultElementParent;
        public Button SellButton => _sellButton;
        public Button ExitToMainMenuButton => _exitToMainMenuButton;
        public Button MixButton => _mixButton;
        public Button EmptyVileButton => _emptyVileButton;
    }
}
