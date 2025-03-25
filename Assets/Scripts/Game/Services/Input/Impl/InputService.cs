using System;
using Zenject;

namespace Game.Services.Input.Impl
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        private readonly IInputProvider _inputProvider;

        public InputService(
            IInputProvider inputProvider
        )
        {
            _inputProvider = inputProvider;
        }

        public void Initialize()
        {
            _inputProvider.InputSystem.Enable();
        }

        public void Dispose()
        {
            _inputProvider.InputSystem.Disable();
        }
    }
}