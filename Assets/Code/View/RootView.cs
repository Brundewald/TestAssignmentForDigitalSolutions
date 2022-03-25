using TestAssingment.Controllers;
using UnityEngine;

namespace TestAssingment.View
{
    public sealed class RootView : MonoBehaviour
    {
        [SerializeField] private ReferenceHolder _prefabs;
        private ControllersProxy _controllers;
        private EntityController _entityController;

        private void Awake()
        {
            _controllers = new ControllersProxy();
            _entityController = new EntityController(_controllers, _prefabs);
            _entityController.Init();
        }
        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _entityController.Clean();
            _controllers.Cleanup();
        }
    }   
}