using Game.Player;
using Game.Player.Models;
using Game.Providers;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class WaterNeed : ANeed
    {
        private WaterModel _waterModel;
        private IPlayerParametersProvider _playerParametersProvider;

        [Inject]
        public void Construct(
            WaterModel waterModel,
            IPlayerParametersProvider playerParametersProvider
        )
        {
            _waterModel = waterModel;
            _playerParametersProvider = playerParametersProvider;
            _waterModel.Value.Subscribe(UpdateView).AddTo(this);
        }
        
        private void Start()
        {
            NeedSlider.maxValue = _playerParametersProvider.PlayerParameters.Water;
        }
    }
}