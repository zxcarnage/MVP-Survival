using UniRx;

namespace Game.Player.Models
{
    public class MetabolismModel
    {
        public ReactiveProperty<int> SkillLevel { get; } = new(1);
    }
}