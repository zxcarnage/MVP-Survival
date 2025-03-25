using Cysharp.Threading.Tasks;
using Db.Collectable;
using Game.Player;

namespace Game.Collectable
{
    public class CollectablePresenter : ICollectablePresenter
    {
        private readonly ICollectableParameters _collectableParameters;
        private readonly InventoryModel _inventoryModel;

        public CollectablePresenter(
            ICollectableParameters collectableParameters,
            InventoryModel inventoryModel
        )
        {
            _collectableParameters = collectableParameters;
            _inventoryModel = inventoryModel;
        }
        
        public void Collect(ECollectableType type)
        {
            var delay = _collectableParameters.CollectTime[type];
            CollectAsync(type, delay).Forget();
        }

        private async UniTaskVoid CollectAsync(ECollectableType type, float collectTime)
        {
            await UniTask.WaitForSeconds(collectTime);
            
            _inventoryModel.Inventory[type]++;
        }
    }
}