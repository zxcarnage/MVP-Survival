using UniRx;

namespace Game.Player.Models
{
    public class SkillPointsModel
    {
        public ReactiveProperty<int> Amount { get; set; } = new(0);
    }
}