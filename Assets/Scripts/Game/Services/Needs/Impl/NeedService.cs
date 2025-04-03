using Game.Player.Models;

namespace Game.Services.Needs.Impl
{
    public class NeedService : INeedService
    {
        private readonly HungerModel _hungerModel;
        private readonly WaterModel _waterModel;

        public NeedService(
            HungerModel hungerModel,
            WaterModel waterModel
        )
        {
            _hungerModel = hungerModel;
            _waterModel = waterModel;
        }
        
        public void DecreaseNeed(float value, ENeedType type)
        {
            switch (type)
            {
                case ENeedType.Water:
                    _waterModel.DecreaseValue(value);
                    break;
                case ENeedType.Hunger:
                    _hungerModel.DecreaseValue(value);
                    break;
            }
        }

        public void IncreaseNeed(int value, ENeedType type)
        {
            switch (type)
            {
                case ENeedType.Water:
                    _waterModel.IncreaseValue(value);
                    break;
                case ENeedType.Hunger:
                    _hungerModel.IncreaseValue(value);
                    break;
            }
        }
    }
}