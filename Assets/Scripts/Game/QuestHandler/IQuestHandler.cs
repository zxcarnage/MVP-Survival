using Game.Collectable;
using UniRx;

namespace Game.QuestHandler
{
    public interface IQuestHandler
    {
        public IReactiveCommand<bool> SwordQuestCompleted { get; }
        public IReactiveCommand<bool> TreeCollectQuestCompleted { get; }
        public IReactiveCommand<bool> PickaxeQuestCompleted { get; }
        public IReactiveCommand<bool> RocksQuestCompleted { get; }
        public IReactiveCommand<bool> ShipQuestCompleted { get; }

        public void Enable();
    }
}