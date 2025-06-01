using System.Collections.Generic;
using UnityEngine;

namespace Db.Quest.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(QuestParameters), fileName = nameof(QuestParameters))]

    public class QuestParameters : ScriptableObject, IQuestParameters
    {
        [SerializeField] private List<string> _quests = new();
        
        [field: SerializeField, TextArea] 
        public string FinalMessage { get; private set; }
        
        public IReadOnlyList<string> Quests => _quests;
    }
}