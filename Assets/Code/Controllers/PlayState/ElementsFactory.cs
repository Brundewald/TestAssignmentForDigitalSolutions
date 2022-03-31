using Assets.Code.Enum;
using TestAssingment.Data;
using TestAssingment.View;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssingment.Controllers
{
    public sealed class ElementsFactory
    {
        private readonly Image _firstElementParent;
        private readonly Image _secondElementParent;
        private readonly Image _resultElementParent;

        public ElementsFactory(HUDInitializer hudInitializer)
        {
            _firstElementParent = hudInitializer.FirstElementParent;
            _secondElementParent = hudInitializer.SecondElementParent;
            _resultElementParent = hudInitializer.ResultElementParent;
        }

        public ElementView CreateElementObject(ElementStruct elementStruct, Transform postion)
        {
            var prefab = elementStruct.Element;
            var spawnedObject = Object.Instantiate(prefab, postion);
            var view = spawnedObject.GetComponent<ElementView>();
            view.ElementStruct = elementStruct;
            PlaceElementsIcon(elementStruct, elementStruct.ElementTag);
            return view;
        }

        public void UpdatePosition(GameObject gameObject, Transform position)
        {
            gameObject.transform.position = position.position;
        }


        private void PlaceElementsIcon(ElementStruct element, TagEnum tag)
        {
            switch (tag)
            {
                case TagEnum.Ingredient:
                {
                    var firstContainerEmpty = !_firstElementParent.IsActive();

                    if (firstContainerEmpty)
                        PlaceOneElementIcon(_firstElementParent, element);
                    else
                        PlaceOneElementIcon(_secondElementParent, element);
                    break;
                }
                case TagEnum.Result:
                    PlaceOneElementIcon(_resultElementParent, element);
                    break;
            }
        }

        private void PlaceOneElementIcon(Image parent,ElementStruct element)
        {
            parent.sprite = element.ElementSprite;
            parent.gameObject.SetActive(true);
            parent.gameObject.name = element.Name;
        }

        public ElementView ClearElement(ElementView elementView)
        {
            var name = elementView.ElementStruct.Name;
            
            if (_firstElementParent.gameObject.name.Equals(name) &&_firstElementParent.gameObject.activeInHierarchy)
                _firstElementParent.gameObject.SetActive(false);
            else if(_secondElementParent.gameObject.name.Equals(name) && _secondElementParent.gameObject.activeInHierarchy)
                _secondElementParent.gameObject.SetActive(false);
            else if(_resultElementParent.gameObject.name.Equals(name) && _resultElementParent.gameObject.activeInHierarchy)
                _resultElementParent.gameObject.SetActive(false);
            return null;
        }
    }   
}