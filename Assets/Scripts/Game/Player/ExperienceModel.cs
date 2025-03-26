using UniRx;

namespace Game.Player
{
    public class ExperienceModel
    {
        public ReactiveProperty<int> Level { get; set; } = new(0);
    }
}