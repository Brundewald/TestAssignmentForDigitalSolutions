using TestAssingment.Data;
using UnityEngine;

namespace TestAssingment.View
{
    public class ElementView: MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public MeshRenderer MeshRenderer => _meshRenderer;
        public ElementStruct ElementStruct { get; set; }
    }
}