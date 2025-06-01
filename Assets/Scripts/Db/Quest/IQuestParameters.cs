using System.Collections.Generic;

namespace Db.Quest
{
    public interface IQuestParameters
    {
        public IReadOnlyList<string> Quests { get; }
        public string FinalMessage { get; }
    }
}