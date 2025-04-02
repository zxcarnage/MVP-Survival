using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class WaterModel
    {
        public ReactiveProperty<int> Value { get; }
        public ReactiveProperty<int> MaxValue { get; }

        public WaterModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new ReactiveProperty<int>(playerParametersProvider.PlayerParameters.Water);
            MaxValue = new(playerParametersProvider.PlayerParameters.Water);
        }
    }
}