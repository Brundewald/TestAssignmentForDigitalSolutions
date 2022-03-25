using TestAssingment.Data;
using UnityEngine;

namespace TestAssingment.View
{
    public class ElementView: MonoBehaviour
    {
        private ElementStruct _elementStruct;

        public ElementStruct ElementStruct
        {
            get => _elementStruct;
            set => _elementStruct = value;
        }
    }
}