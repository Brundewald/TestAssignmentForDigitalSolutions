using System;
using TestAssingment.Data;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestAssingment.Controllers
{
    public class ElementHandler: IDisposable, ICleanup
    {
        private readonly PlayerInputHandler _playerInputHandler;
        private readonly ElementsFactory _elementFactory;
        private readonly RecipeHolder _recipeHolder;
        private readonly ElementsHolder _elementsHolder;
        private ElementView _secondElement;
        private ElementView _firstElement;
        private ElementView _resultElement;


        public ElementHandler(ReferenceHolder referenceHolder, HUDInitializer hudInitializer, PlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;
            _elementFactory = new ElementsFactory(hudInitializer);
            _recipeHolder = referenceHolder.RecipeHolder;
            _elementsHolder = referenceHolder.ElementsHolder;
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
            _playerInputHandler.OnElementFound += ElementSpawnTesting;
            _playerInputHandler.OnMixButtonPressed += CheckRecipe;
            _playerInputHandler.OnEmptyVilePressed += EmptyVile;
        }
        
        private void UnsubscribeEvents()
        {
            _playerInputHandler.OnButtonSellPressed -= SellElement;
            _playerInputHandler.OnElementFound -= ElementSpawnTesting;
            _playerInputHandler.OnMixButtonPressed -= CheckRecipe;
            _playerInputHandler.OnEmptyVilePressed -= EmptyVile;
        }

        private void ElementSpawnTesting(int index)
        {
            SpawnElement(index);
        }

        private void SpawnElement(int index)
        {
            if (_firstElement != null && _secondElement != null) return;
            var elementToSpawn = _elementsHolder.Elements[index];
            var element = _elementFactory.CreateElement(elementToSpawn);
            if (_firstElement is null)
                _firstElement = element;
            else if (_secondElement is null)
                _secondElement = element;
        }

        private void CheckRecipe()
        {
            if(_resultElement is null && _firstElement !=null && _secondElement != null)
            {
                
                var firstElementToFind = _firstElement.ElementStruct.Name;
                var secondElementToFind = _secondElement.ElementStruct.Name;
                var elementsTheSame = firstElementToFind.Equals(secondElementToFind);
                
                Debug.Log($"{firstElementToFind} {secondElementToFind}");
                
                if(!elementsTheSame)
                {
                    foreach (var recipe in _recipeHolder.Recipies)
                    {
                        var firstIngredientCheck = recipe.FirstElement.Name.Equals(firstElementToFind)||recipe.SecondElement.Name.Equals(firstElementToFind);
                        var secondIngredientCheck = recipe.SecondElement.Name.Equals(secondElementToFind)||recipe.FirstElement.Name.Equals(secondElementToFind);

                        Debug.Log($"{firstIngredientCheck} {secondIngredientCheck}");

                        if (!firstIngredientCheck || !secondIngredientCheck) continue;
                        MixElements(recipe);
                        return;
                    }
                }
            }
        }

        private void MixElements(RecipeStruct recipe)
        {
            _resultElement = _elementFactory.CreateElement(recipe.Result);
            _firstElement = _elementFactory.DestroyElement(_firstElement);
            _secondElement = _elementFactory.DestroyElement(_secondElement);
        }

        private void SellElement()
        {
            if (_resultElement != null)
            {
                Debug.Log($"{_resultElement.ElementStruct.Name} sold");
                _resultElement = _elementFactory.DestroyElement(_resultElement);
            }
        }

        private void EmptyVile()
        {
            _firstElement = _elementFactory.DestroyElement(_firstElement);
            _secondElement = _elementFactory.DestroyElement(_secondElement);
        }
    }
}
