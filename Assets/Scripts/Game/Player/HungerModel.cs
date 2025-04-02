using UniRx;

namespace Game.Player
{
    public class HungerModel
    {
        public ReactiveProperty<int> Value { get; set; } = new (100);
    }
}