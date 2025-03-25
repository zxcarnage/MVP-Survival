using System.Collections.Generic;
using Game.Collectable;

namespace Game.Player
{
    public class InventoryModel
    {
        public Dictionary<ECollectableType, int> Inventory = new ();
    }
}