using System;
using Game.Collectable;
using UniRx;
using UnityEngine;

namespace Game.Player.Models
{
    public class InventoryModel
    {
        public readonly ReactiveDictionary<ECollectableType, int> Inventory = new();

        public InventoryModel()
        {
            var collectablesToArray = Enum.GetValues(typeof(ECollectableType));

            foreach (var collectable in collectablesToArray)
            {
                if ((ECollectableType)collectable != ECollectableType.None)
                    Inventory.Add((ECollectableType)collectable, 0);
            }
        }

        public void Consume(ECollectableType consumedType)
        {
            Inventory[consumedType] = Mathf.Clamp(Inventory[consumedType] - 1, 0, int.MaxValue);
        }
    }
}