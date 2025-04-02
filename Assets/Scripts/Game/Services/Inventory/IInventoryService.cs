using Game.Collectable;

namespace Game.Services.Inventory
{
    public interface IInventoryService
    {
        public void ActivateCollectable(ECollectableType collectableType);
    }
}