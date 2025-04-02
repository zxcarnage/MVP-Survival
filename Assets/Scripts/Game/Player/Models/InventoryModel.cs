using System;
using Game.Collectable;
using UniRx;

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
    }
}