using UniRx;

namespace Game.Player.Models
{
    public class DrinkerModel
    {
        public ReactiveProperty<int> Level = new(1);
    }
}