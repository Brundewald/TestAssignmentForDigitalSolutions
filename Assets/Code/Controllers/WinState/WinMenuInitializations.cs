using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using Object = UnityEngine.Object;

namespace TestAssingment.Controllers
{
    public class WinMenuInitializations: ICleanup, IDisposable
    {
        private readonly WinMenuView _winMenuView;

        public WinMenuView WinMenuView => _winMenuView;
        
        public WinMenuInitializations(ReferenceHolder referenceHolder)
        {
            var winMenuPrefab = referenceHolder.WinMenu;
            var winMenuObject = Object.Instantiate(winMenuPrefab);
            _winMenuView = winMenuObject.GetComponent<WinMenuView>();
        }

        public void Cleanup()
        {
            Object.Destroy(_winMenuView.gameObject);
        }

        public void Dispose()
        {
            Object.Destroy(_winMenuView.gameObject);
        }
    }
}