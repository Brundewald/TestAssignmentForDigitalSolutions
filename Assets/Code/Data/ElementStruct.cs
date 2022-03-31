using System;
using Assets.Code.Enum;
using UnityEngine;

namespace TestAssingment.Data
{
    [Serializable]
    public struct ElementStruct
    {
        public TagEnum ElementTag;
        public string Name;
        public GameObject Element;
        public Sprite ElementSprite;
    }
}