using System;
using System.Collections.Generic;
using TestAssingment.Interfaces;

namespace TestAssingment.Controllers
{
    public sealed class ControllersProxy
    {
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IDisposable> _disposableControllers;

        public ControllersProxy()
        {
            _initializationControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _cleanupControllers = new List<ICleanup>();
            _disposableControllers = new List<IDisposable>();
        }

        public void Add(IController controller)
        {
                if (controller is IInitialization initializationController)
                {
                    _initializationControllers.Add(initializationController);
                }

                if (controller is IExecute executeController)
                {
                    _executeControllers.Add(executeController);
                }

                if (controller is ICleanup cleanupController)
                {
                    _cleanupControllers.Add(cleanupController);
                }

                if (controller is IDisposable disposableController)
                {
                    _disposableControllers.Add(disposableController);
                }
        }

        public void Clear()
        {
            _initializationControllers.Clear();
            _executeControllers.Clear();
            _cleanupControllers.Clear();
            _disposableControllers.Clear();
        }

        public void Initialize()
        {
            foreach (var controller in _initializationControllers)
            {
                controller.Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            if(_executeControllers!= null)
            {
                for (var i =0; i < _executeControllers.Count; i++)
                {
                    _executeControllers[i].Execute(deltaTime);
                }
            }
        }

        public void Cleanup()
        {
            foreach (var controller in _cleanupControllers)
            {
                controller.Cleanup();
            }
        }

        public void Dispose()
        {
            foreach (var controller in _disposableControllers)
            {
                controller.Dispose();
            }
        }
    }   
}
