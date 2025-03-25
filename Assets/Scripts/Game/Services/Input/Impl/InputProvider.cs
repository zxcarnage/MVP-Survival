namespace Game.Services.Input.Impl
{
    public class InputProvider : IInputProvider
    {
        public InputSystem InputSystem { get; private set; }

        public InputProvider(
            InputSystem inputSystem
        )
        {
            SetInputSystem(inputSystem);
        }
        
        public void SetInputSystem(InputSystem inputSystem)
        {
            InputSystem = inputSystem;
        }
    }
}