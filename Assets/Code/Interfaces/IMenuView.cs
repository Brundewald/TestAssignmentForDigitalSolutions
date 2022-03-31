using UnityEngine.UI;

namespace Assets.Code.Interfaces
{
    public interface IMenuView
    {
        public Button PlayButton { get; }
        public Button ExitButton { get; }
    }
}