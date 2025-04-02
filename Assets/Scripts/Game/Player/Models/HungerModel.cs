using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class HungerModel
    {
        public ReactiveProperty<int> Value { get; }
        public ReactiveProperty<int> MaxValue { get; }

        public HungerModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new (playerParametersProvider.PlayerParameters.Hunger);
            MaxValue = new(playerParametersProvider.PlayerParameters.Hunger);
        }
    }
}