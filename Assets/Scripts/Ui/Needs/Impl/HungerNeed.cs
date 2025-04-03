using Game.Player.Models;
using Game.Providers;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class HungerNeed : ANeed
    {
        [Inject]
        public void Construct(
            HungerModel hungerModel
        )
        {
            hungerModel.Value.Subscribe(UpdateView).AddTo(this);
            hungerModel.MaxValue.Subscribe(UpdateMax).AddTo(this);
        }

        private void UpdateMax(float newValue)
        {
            NeedSlider.maxValue = newValue;
        }
    }
}