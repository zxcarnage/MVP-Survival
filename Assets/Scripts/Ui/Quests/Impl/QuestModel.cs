using System.Collections.Generic;
using Db.Quest;

namespace Ui.Quests.Impl
{
    public class QuestModel : IQuestModel
    {
        private readonly Queue<string> _questQueue;

        public QuestModel(
            IQuestParameters questParameters
        )
        {
            _questQueue = new Queue<string>();
            foreach (var quest in questParameters.Quests)
            {
                _questQueue.Enqueue(quest);
            }
        }
        
        public bool TryGetNewQuest(out string quest)
        {
            return _questQueue.TryDequeue(out quest);
        }
    }
}