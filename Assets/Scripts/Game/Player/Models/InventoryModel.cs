using System;
using Game.Collectable;
using UniRx;
using UnityEngine;

namespace Game.Player.Models
{
    public class InventoryModel
    {
        public readonly ReactiveDictionary<ECollectableType, int> ConsumableInventory = new();

        public InventoryModel()
        {
            var collectablesToArray = Enum.GetValues(typeof(ECollectableType));

            foreach (var collectable in collectablesToArray)
            {
                if ((ECollectableType)collectable != ECollectableType.None)
                    ConsumableInventory.Add((ECollectableType)collectable, 0);
            }
        }

        public void Consume(ECollectableType consumedType, int amount = 1)
        {
            ConsumableInventory[consumedType] = Mathf.Clamp(ConsumableInventory[consumedType] - amount, 0, int.MaxValue);
        }
    }
}