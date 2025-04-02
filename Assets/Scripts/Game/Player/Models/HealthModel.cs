using Game.Providers;
using UniRx;

namespace Game.Player.Models
{
    public class HealthModel
    {
        ReactiveProperty<int> Value { get; }

        public HealthModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new(playerParametersProvider.PlayerParameters.Health);
        }
    }
}