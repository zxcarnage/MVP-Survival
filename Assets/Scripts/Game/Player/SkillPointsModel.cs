using UniRx;

namespace Game.Player
{
    public class SkillPointsModel
    {
        public ReactiveProperty<int> Amount { get; set; } = new(0);
    }
}