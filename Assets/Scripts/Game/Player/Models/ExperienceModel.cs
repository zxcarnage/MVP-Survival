using UniRx;

namespace Game.Player.Models
{
    public class ExperienceModel
    {
        public ReactiveProperty<int> Level { get; set; } = new(0);
    }
}