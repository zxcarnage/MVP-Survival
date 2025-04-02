namespace Game.Services.Needs
{
    public interface INeedService
    {
        void DecreaseNeed(int value, ENeedType type);
        void IncreaseNeed(int value, ENeedType type);
    }
}