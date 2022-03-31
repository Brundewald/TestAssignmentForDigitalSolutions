using TestAssingment.Data;
using TestAssingment.View;
using TMPro;
using UnityEngine;

namespace TestAssingment.Controllers
{
    public sealed class ObjectiveHandler
    {
        private readonly RecipeHolder _recipeHolder;
        private readonly TextMeshProUGUI _objectiveField;
        private RecipeStruct _recipe;

        public RecipeStruct Recipe => _recipe;

        public ObjectiveHandler(ReferenceHolder referenceHolder, HUDInitializer hudInitializer)
        {
            _recipeHolder = referenceHolder.RecipeHolder;
            _objectiveField = hudInitializer.ObjectiveField;
        }

        public void SetObjective()
        {
            var random = Random.Range(0, _recipeHolder.Recipies.Capacity);
            _recipe = _recipeHolder.Recipies[random];
            var objectiveName = _recipe.Result.Name;
            var firstElementName = _recipe.FirstElement.Name;
            var secondElementName = _recipe.SecondElement.Name;
            _objectiveField.text = $"To find {objectiveName} you need {firstElementName} and {secondElementName}";
            _objectiveField.color = Color.yellow;
        }

        public bool ElementsMatch(ElementView firstElement, ElementView secondElement)
        {
            var firstElementToFind = firstElement.ElementStruct.Name;
            var secondElementToFind = secondElement.ElementStruct.Name;
            var elementsTheSame = firstElementToFind.Equals(secondElementToFind);
                
            if(!elementsTheSame)
            {
                var firstIngredientCheck = _recipe.FirstElement.Name.Equals(firstElementToFind)||_recipe.SecondElement.Name.Equals(firstElementToFind);
                var secondIngredientCheck = _recipe.SecondElement.Name.Equals(secondElementToFind)||_recipe.FirstElement.Name.Equals(secondElementToFind);
                if (!firstIngredientCheck || !secondIngredientCheck) return false;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}