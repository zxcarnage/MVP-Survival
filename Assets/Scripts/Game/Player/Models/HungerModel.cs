using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class HungerModel
    {
        public ReactiveProperty<int> Value { get; }

        public HungerModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new ReactiveProperty<int>(playerParametersProvider.PlayerParameters.Hunger);
        }
    }
}