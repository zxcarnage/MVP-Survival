using Game.Player.Models;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class Health : ANeed
    {
        [Inject]
        private void Construct(
            HealthModel healthModel
        )
        {
            healthModel.Value.Subscribe(UpdateView).AddTo(this);
            healthModel.MaxValue.Subscribe(UpdateMax).AddTo(this);
        }
        
        private void UpdateMax(int newValue)
        {
            NeedSlider.maxValue = newValue;
        }
    }
}