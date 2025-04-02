using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class LuckModel
    {
        ReactiveProperty<float> Value { get; }

        public LuckModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new(playerParametersProvider.PlayerParameters.Luck);
        }
    }
}