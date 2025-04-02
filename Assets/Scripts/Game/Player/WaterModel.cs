using UniRx;

namespace Game.Player
{
    public class WaterModel
    {
        public ReactiveProperty<int> Value { get; set; } = new (100);
    }
}