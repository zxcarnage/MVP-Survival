using Db.Quest;
using Game.QuestHandler;
using UniRx;

namespace Ui.Quests.Impl
{
    public class QuestPresenter : IQuestPresenter
    {
        private readonly IQuestModel _questModel;
        private readonly IQuestParameters _questParameters;
        private readonly IQuestHandler _questHandler;

        private QuestView _questView;

        public QuestPresenter(
            IQuestModel questModel,
            IQuestParameters questParameters,
            IQuestHandler questHandler
        )
        {
            _questModel = questModel;
            _questParameters = questParameters;
            _questHandler = questHandler;
        }
        
        
        public void Enable(QuestView questView)
        {
            _questView = questView;
            _questView.UpdateView(GetNewQuest());
            _questHandler.SwordQuestCompleted.Subscribe(_ => _questView.UpdateView(GetNewQuest()));
            _questHandler.TreeCollectQuestCompleted.Subscribe(_ => _questView.UpdateView(GetNewQuest()));
            _questHandler.PickaxeQuestCompleted.Subscribe(_ => _questView.UpdateView(GetNewQuest()));
            _questHandler.RocksQuestCompleted.Subscribe(_ => _questView.UpdateView(GetNewQuest()));
            _questHandler.ShipQuestCompleted.Subscribe(_ => _questView.UpdateView(GetNewQuest()));
        }

        private string GetNewQuest()
        {
            return _questModel.TryGetNewQuest(out var newQuest) ? newQuest : _questParameters.FinalMessage;
        }
    }
}