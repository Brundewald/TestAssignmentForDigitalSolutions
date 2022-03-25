using System.Collections.Generic;
using UnityEngine;

namespace TestAssingment.Data
{
    [CreateAssetMenu(menuName = "Data/ElementsHolder", fileName = "ElementsHolder")]
    
    public class ElementsHolder: ScriptableObject
    {
        public List<ElementStruct> Elements;
    }
}