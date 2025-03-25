namespace Game.Services.Input
{
    public interface IInputProvider
    {
        public InputSystem InputSystem { get; }
        
        public void SetInputSystem(InputSystem inputSystem);
    }
}