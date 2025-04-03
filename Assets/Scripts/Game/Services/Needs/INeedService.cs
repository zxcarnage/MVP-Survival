namespace Game.Services.Needs
{
    public interface INeedService
    {
        void DecreaseNeed(float value, ENeedType type);
        void IncreaseNeed(int value, ENeedType type);
    }
}