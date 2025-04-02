using Game.Player;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class WaterNeed : ANeed
    {
        private WaterModel _waterModel;

        [Inject]
        public void Construct(
            WaterModel waterModel
        )
        {
            _waterModel = waterModel;
            _waterModel.Value.Subscribe(UpdateView).AddTo(this);
        }
    }
}