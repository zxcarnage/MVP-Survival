using System;
using System.Collections.Generic;
using Game.Collectable;

namespace Game.Player
{
    public class InventoryModel
    {
        public Dictionary<ECollectableType, int> Inventory = new ();

        public InventoryModel()
        {
            var collectablesToArray = Enum.GetValues(typeof(ECollectableType));

            foreach (var collectable in collectablesToArray)
            {
                if((ECollectableType)collectable != ECollectableType.None)
                    Inventory.Add((ECollectableType)collectable, 0);
            }
        }
    }
}