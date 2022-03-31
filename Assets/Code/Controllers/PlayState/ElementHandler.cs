using System;
using System.Collections.Generic;
using TestAssingment.Data;
using TestAssingment.Interfaces;
using TestAssingment.View;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Object = UnityEngine.Object;

namespace TestAssingment.Controllers
{
    public class ElementHandler: IDisposable, ICleanup
    {
        private readonly PlayerInputHandler _playerInputHandler;
        private readonly ImageTrackingHandler _imageTrackingHandler;
        private readonly ElementsFactory _elementFactory;
        private readonly ObjectiveHandler _objectiveHandler;
        private readonly ElementsHolder _elementsHolder;
        private readonly List<ElementView> _listOfSpawnedElements;
        private readonly List<string> _listOfNames;
        private readonly float _distanceThreshold;
        
        private float _recipeCost;
        private ElementView _firstElement;
        private ElementView _secondElement;
        private ElementView _resultElement;

        public event Action<float> OnResultSold;


        public ElementHandler(ReferenceHolder referenceHolder, HUDInitializer hudInitializer,
            PlayerInputHandler playerInputHandler, ImageTrackingHandler imageTrackingHandler)
        {
            _playerInputHandler = playerInputHandler;
            _imageTrackingHandler = imageTrackingHandler;
            _elementFactory = new ElementsFactory(hudInitializer);
            _objectiveHandler = new ObjectiveHandler(referenceHolder, hudInitializer);
            _elementsHolder = referenceHolder.ElementsHolder;
            _listOfSpawnedElements = new List<ElementView>();
            _listOfNames = new List<string>();
            _distanceThreshold = referenceHolder.GameSettings.DistanceThreshold;
            _objectiveHandler.SetObjective();
            SubscribeEvents();
        }
        
        public void Dispose()
        {
            UnsubscribeEvents();
        }

        public void Cleanup()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _playerInputHandler.OnButtonSellPressed += SellElement;
            _playerInputHandler.OnMixButtonPressed += CheckRecipe;
            _playerInputHandler.OnEmptyVilePressed += EmptyVile;
            _imageTrackingHandler.OnImageCaught += UpdateObjects;
            _imageTrackingHandler.OnPositionTracked += UpdatePosition;
        }

        private void UnsubscribeEvents()
        {
            _playerInputHandler.OnButtonSellPressed -= SellElement;
            _playerInputHandler.OnMixButtonPressed -= CheckRecipe;
            _playerInputHandler.OnEmptyVilePressed -= EmptyVile;
            _imageTrackingHandler.OnImageCaught -= UpdateObjects;
            _imageTrackingHandler.OnPositionTracked -= UpdatePosition;
        }

        private void UpdateObjects(string name, Transform position)
        {
            foreach (var elements in _elementsHolder.Elements)
            {
                if (!_listOfNames.Contains(name))
                {
                    if (!elements.Name.Equals(name)) continue;
                    var element = _elementFactory.CreateElementObject(elements, position);
                    
                    _listOfSpawnedElements.Add(element);
                    _listOfNames.Add(element.ElementStruct.Name);
                    
                    if (_firstElement is null)
                    {
                        _firstElement = element;
                    }
                    else if (_secondElement is null && !_firstElement.ElementStruct.Name.Equals(name))
                    {
                        _secondElement = element;
                    }
                }
            }

            if (_firstElement != null && _secondElement != null)
                _imageTrackingHandler.IsObjectSpawned(true);
        }

        private void UpdatePosition(string name, Transform position)
        {
            foreach (var elementView in _listOfSpawnedElements)
            {
                if (elementView.ElementStruct.Name.Equals(name))
                    _elementFactory.UpdatePosition(elementView.gameObject, position);
            }

            if (CheckDistance())
            {
                CheckRecipe();
            }
        }

        private bool CheckDistance()
        {
            var firstElementPosition = _firstElement.gameObject.transform.position;
            var secondElementPosition = _secondElement.gameObject.transform.position;
            var distance = (firstElementPosition - secondElementPosition).magnitude;
            var elementsClose = distance < _distanceThreshold;
            return elementsClose;
        }


        private void CheckRecipe()
        {
            var elementsMatch = _objectiveHandler.ElementsMatch(_firstElement, _secondElement);
            
            if(elementsMatch)
            {
                GetResult(_objectiveHandler.Recipe);
            }
            else
            {
                WrongElements();
            }
        }

        private void WrongElements()
        {
            _firstElement.MeshRenderer.material.color = Color.black;
            _secondElement.MeshRenderer.material.color = Color.black;
        }

        private void GetResult(RecipeStruct recipe)
        {
            _resultElement = _elementFactory.CreateElementObject(recipe.Result, null);
            _recipeCost = recipe.Cost;
            DestroySpawnedObjects();
        }

        private void SellElement()
        {
            if (_resultElement != null)
            {
                _resultElement = _elementFactory.ClearElement(_resultElement);
                OnResultSold?.Invoke(_recipeCost);
                _objectiveHandler.SetObjective();
                _imageTrackingHandler.IsObjectSpawned(false);
            }
        }

        private void EmptyVile()
        {
            DestroySpawnedObjects();
            _imageTrackingHandler.IsObjectSpawned(false);
        }

        private void DestroySpawnedObjects()
        {
            _firstElement = _elementFactory.ClearElement(_firstElement);
            _secondElement = _elementFactory.ClearElement(_secondElement);
            foreach (var elementView in _listOfSpawnedElements)
            {
                var gameObject = elementView.gameObject;
                Object.Destroy(gameObject);
            }
            _listOfNames.Clear();
            _listOfSpawnedElements.Clear();
        }
    }
}


