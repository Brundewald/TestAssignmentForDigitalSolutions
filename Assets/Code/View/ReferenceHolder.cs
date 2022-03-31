using TestAssingment.Data;
using TestAssingment.Enum;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace TestAssingment.View
{
    public sealed class ReferenceHolder: MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPrefab;
        [SerializeField] private GameObject _gameHUD;
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private RecipeHolder _recipeHolder;
        [SerializeField] private ElementsHolder _elementsHolder;
        [SerializeField] private ARTrackedImageManager _arTrackedImageManager;
        [SerializeField] private Camera _arCamera;
        [SerializeField] private ARSession _arSession;
        
        
        public GameObject MainMenuPrefab => _mainMenuPrefab;
        public GameObject GameHUD => _gameHUD;
        public GameObject WinMenu => _winMenu;
        public GameSettings GameSettings => _gameSettings;
        public RecipeHolder RecipeHolder => _recipeHolder;
        public ElementsHolder ElementsHolder => _elementsHolder;
        public ARTrackedImageManager ARTrackedImageManager => _arTrackedImageManager;
        public Camera ARCamera => _arCamera;
        public ARSession ArSession => _arSession;
    }   
}