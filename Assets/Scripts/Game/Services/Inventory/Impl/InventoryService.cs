using System;
using Db.Collectable;
using Game.Collectable;
using Game.Player.Models;

namespace Game.Services.Inventory.Impl
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryModel _inventoryModel;
        private readonly ICollectableParameters _collectableParameters;
        private readonly HungerModel _hungerModel;
        private readonly WaterModel _waterModel;

        public InventoryService(
            InventoryModel inventoryModel,
            ICollectableParameters collectableParameters,
            HungerModel hungerModel,
            WaterModel waterModel
        )
        {
            _inventoryModel = inventoryModel;
            _collectableParameters = collectableParameters;
            _hungerModel = hungerModel;
            _waterModel = waterModel;
        }

        public void ActivateCollectable(ECollectableType collectableType)
        {
            if (_inventoryModel.Inventory[collectableType] == 0)
                return;

            _inventoryModel.Consume(collectableType);
            var targetSaturation = 0;
            var targetThirstIncrease = 0;
            switch (collectableType)
            {
                case ECollectableType.Watermelon:
                    AssignTarget(_collectableParameters.Watermelon);
                    break;
                case ECollectableType.Berry:
                    AssignTarget(_collectableParameters.Berry);
                    break;
                case ECollectableType.Coconut:
                    AssignTarget(_collectableParameters.Coconut);
                    break;
                case ECollectableType.Meet:
                    AssignTarget(_collectableParameters.Meet);
                    break;
            }

            _hungerModel.IncreaseValue(targetSaturation);
            _waterModel.IncreaseValue(targetThirstIncrease);

            return;

            void AssignTarget(CollectibleVO targetVo)
            {
                targetSaturation = targetVo.Saturation;
                targetThirstIncrease = targetVo.Thirst;
            }
        }
    }
}