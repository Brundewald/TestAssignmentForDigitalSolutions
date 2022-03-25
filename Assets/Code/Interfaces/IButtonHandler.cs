using System;
using TestAssingment.Enum;

namespace Assets.Code.Interfaces
{
    public interface IButtonHandler
    {
        public event Action<ButtonTokenEnum> OnButtonPressed;
    }
}