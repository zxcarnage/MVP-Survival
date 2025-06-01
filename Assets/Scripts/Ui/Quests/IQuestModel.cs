namespace Ui.Quests
{
    public interface IQuestModel
    {
        public bool TryGetNewQuest(out string quest);
    }
}