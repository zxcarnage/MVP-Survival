using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class LuckModel
    {
        public ReactiveProperty<float> Value { get; }
        public ReactiveProperty<float> MaxValue { get; }

        public LuckModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new(playerParametersProvider.PlayerParameters.Luck);
            MaxValue = new(playerParametersProvider.PlayerParameters.Luck);
        }
    }
}