using Game.Player.Models;
using Game.Providers;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class WaterNeed : ANeed
    {
        [Inject]
        public void Construct(
            WaterModel waterModel
        )
        {
            waterModel.Value.Subscribe(UpdateView).AddTo(this);
            waterModel.MaxValue.Subscribe(UpdateMax).AddTo(this);
        }
        
        private void UpdateMax(int newValue)
        {
            NeedSlider.maxValue = newValue;
        }
    }
}