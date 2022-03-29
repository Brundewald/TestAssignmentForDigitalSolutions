using Assets.Code.Enum;
using TestAssingment.Data;
using TestAssingment.View;
using UnityEngine;

namespace TestAssingment.Controllers
{
    public sealed class ElementsFactory
    {
        private readonly Transform _firstElementParent;
        private readonly Transform _secondElementParent;
        private readonly Transform _resultElementParent;

        public ElementsFactory(HUDInitializer hudInitializer)
        {
            _firstElementParent = hudInitializer.FirstElementParent;
            _secondElementParent = hudInitializer.SecondElementParent;
            _resultElementParent = hudInitializer.ResultElementParent;
        } 

        public ElementView CreateElement(ElementStruct elementStruct)
        {
            var element = elementStruct;
            var prefab = elementStruct.Element;
            var spawnedObject = Object.Instantiate(prefab);
            var view = spawnedObject.GetComponent<ElementView>();
            view.ElementStruct = elementStruct;
            PlaceElements(spawnedObject, element.ElementTag);
            return view;
        }

        private void PlaceElements(GameObject element, TagEnum tag)
        {
            switch (tag)
            {
                case TagEnum.Ingredient:
                {
                    var firstContainerEmpty = _firstElementParent.childCount == 0;

                    if (firstContainerEmpty)
                        PlaceOneElement(_firstElementParent, element);
                    else
                        PlaceOneElement(_secondElementParent, element);
                    break;
                }
                case TagEnum.Result:
                    PlaceOneElement(_resultElementParent, element);
                    break;
            }
        }

        private void PlaceOneElement(Transform parent,GameObject element)
        {
            element.transform.SetParent(parent);
            element.transform.position = parent.position;
        }

        public ElementView DestroyElement(ElementView element)
        {
            Object.Destroy(element.gameObject);
            return null;
        }
    }   
}