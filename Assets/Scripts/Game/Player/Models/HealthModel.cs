using Game.Providers;
using UniRx;
using UnityEngine;

namespace Game.Player.Models
{
    public class HealthModel
    {
        public ReactiveProperty<int> Value { get; }
        public ReactiveProperty<int> MaxValue { get; }

        public HealthModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new(playerParametersProvider.PlayerParameters.Health);
            MaxValue = new(playerParametersProvider.PlayerParameters.Health);
        }
        
        public void IncreaseValue(int value)
        {
            Value.Value = Mathf.Clamp(Value.Value + value, 0, MaxValue.Value);
        }

        public void DecreaseValue(int value)
        {
            Value.Value = Mathf.Clamp(Value.Value - value, 0, MaxValue.Value);
        }
    }
}