using System.Collections.Generic;
using UnityEngine;

namespace TestAssingment.Data
{
    [CreateAssetMenu(menuName = "Data/RecipeHolder", fileName = "RecipeHolder")]
    public class RecipeHolder: ScriptableObject
    {
        public List<RecipeStruct> Recipies;
    }
}