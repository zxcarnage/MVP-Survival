using Game.Player.Models;
using Game.Providers;

namespace Game.Utils
{
    public class NeedsInit
    {
        public NeedsInit(
            IPlayerParametersProvider playerParametersProvider,
            WaterModel waterModel,
            LuckModel luckModel,
            HungerModel hungerModel
        )
        {
            waterModel.MaxValue.Value = playerParametersProvider.PlayerParameters.Water;
            luckModel.MaxValue.Value = playerParametersProvider.PlayerParameters.Luck;
            hungerModel.MaxValue.Value = playerParametersProvider.PlayerParameters.Hunger;
        }
    }
}