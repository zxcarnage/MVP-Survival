using Game.Providers;
using UniRx;
using UnityEngine;

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