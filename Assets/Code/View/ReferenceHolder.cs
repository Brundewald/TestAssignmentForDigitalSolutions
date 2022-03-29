using TestAssingment.Data;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace TestAssingment.View
{
    public sealed class ReferenceHolder: MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPrefab;
        [SerializeField] private GameObject _gameHUD;
        [SerializeField] private RecipeHolder _recipeHolder;
        [SerializeField] private ElementsHolder _elementsHolder;
        [SerializeField] private Transform _parent;
        [SerializeField] private ARTrackedImageManager _arTrackedImageManager;
        
        
        public GameObject MainMenuPrefab => _mainMenuPrefab;
        public GameObject GameHUD => _gameHUD;
        public RecipeHolder RecipeHolder => _recipeHolder;
        public ElementsHolder ElementsHolder => _elementsHolder;
        public Transform Parent => _parent;

        public ARTrackedImageManager ARTrackedImageManager => _arTrackedImageManager;
    }   
}