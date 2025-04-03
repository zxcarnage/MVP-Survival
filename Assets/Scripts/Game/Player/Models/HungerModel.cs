using Game.Providers;
using UniRx;
using UnityEngine;

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