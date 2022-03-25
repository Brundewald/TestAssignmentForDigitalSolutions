using System;

namespace TestAssingment.Interfaces
{
    public interface IInputProxy
    {
        event Action<float> OnAxisChange;

        void GetAxis();
    }
}