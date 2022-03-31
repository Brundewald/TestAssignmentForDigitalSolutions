using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestAssingment.Controllers
{
    public sealed class MainMenuInitialization:IController, IDisposable
    {
        private readonly GameObject _mainMenu;
        private readonly MainMenuView _mainMenuView;
        
        public MainMenuView MainMenuView => _mainMenuView;
        
        public MainMenuInitialization(GameObject mainMenuPrefab)
        {
            _mainMenu = Object.Instantiate(mainMenuPrefab);
            _mainMenuView = _mainMenu.GetComponent<MainMenuView>();
            var canvas = _mainMenuView.Canvas;
            canvas.worldCamera = Camera.main;
        }
        
        public void Dispose()
        {
            Object.Destroy(_mainMenu);
        }
    }       
}
