using Game.Providers;
using UniRx;
using UnityEngine;

namespace Game.Player.Models
{
    public class HungerModel
    {
        public ReactiveProperty<float> Value { get; }
        public ReactiveProperty<float> MaxValue { get; }

        public HungerModel(
            IPlayerParametersProvider playerParametersProvider
        )
        {
            Value = new (playerParametersProvider.PlayerParameters.Hunger);
            MaxValue = new(playerParametersProvider.PlayerParameters.Hunger);
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