using System;

namespace TestAssingment.Data
{
    [Serializable]
    public struct RecipeStruct
    {
        public ElementStruct FirstElement;
        public ElementStruct SecondElement;
        public ElementStruct Result;
        public float Cost;
        public int ElementCount;
    }
}