using Game.Player;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class HungerNeed : ANeed
    {
        private HungerModel _hungerModel;

        [Inject]
        public void Construct(
            HungerModel hungerModel
        )
        {
            _hungerModel = hungerModel;
            _hungerModel.Value.Subscribe(UpdateView).AddTo(this);
        }
    }
}