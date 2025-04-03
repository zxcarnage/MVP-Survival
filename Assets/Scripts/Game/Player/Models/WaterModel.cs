using Game.Providers;
using UniRx;
using UnityEngine;

namespace Game.Player.Models
{
    public class WaterModel
    {
        public ReactiveProperty<float> Value { get; }
        public ReactiveProperty<float> MaxValue { get; }

        public WaterModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new ReactiveProperty<float>(playerParametersProvider.PlayerParameters.Water);
            MaxValue = new(playerParametersProvider.PlayerParameters.Water);
        }

        public void IncreaseValue(float value)
        {
            Value.Value = Mathf.Clamp(Value.Value + value, 0, MaxValue.Value);
        }

        public void DecreaseValue(float value)
        {
            Value.Value = Mathf.Clamp(Value.Value - value, 0, MaxValue.Value);
        }
    }
}