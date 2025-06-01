using Game.Collectable;
using Game.Player.Models;
using UniRx;

namespace Game.QuestHandler.Impl
{
    public class QuestHandler : IQuestHandler
    {
        private readonly InventoryModel _inventoryModel;
        public IReactiveCommand<bool> SwordQuestCompleted { get; } = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> TreeCollectQuestCompleted { get; } = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> PickaxeQuestCompleted { get; } = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> RocksQuestCompleted { get; } = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> ShipQuestCompleted { get; } = new ReactiveCommand<bool>();

        public QuestHandler(
            InventoryModel inventoryModel
        )
        {
            _inventoryModel = inventoryModel;
        }

        public void Enable()
        {
            _inventoryModel.ConsumableInventory.ObserveReplace().Subscribe(HandleResourcesQuests);
        }

        private void HandleResourcesQuests(DictionaryReplaceEvent<ECollectableType, int> evt)
        {
            switch (evt.Key)
            {
                case ECollectableType.Wood:
                    if (evt.NewValue == 10)
                        TreeCollectQuestCompleted.Execute(true);
                    break;
                case ECollectableType.Rock:
                    if (evt.NewValue == 5)
                        RocksQuestCompleted.Execute(true);
                    break;
            }
        }
    }
}