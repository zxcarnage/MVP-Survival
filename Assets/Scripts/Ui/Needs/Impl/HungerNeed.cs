using System;
using Game.Player;
using Game.Player.Models;
using Game.Providers;
using UniRx;
using Zenject;

namespace Ui.Needs.Impl
{
    public class HungerNeed : ANeed
    {
        private HungerModel _hungerModel;
        private IPlayerParametersProvider _playerParametersProvider;

        [Inject]
        public void Construct(
            HungerModel hungerModel,
            IPlayerParametersProvider playerParametersProvider
        )
        {
            _hungerModel = hungerModel;
            _playerParametersProvider = playerParametersProvider;
            _hungerModel.Value.Subscribe(UpdateView).AddTo(this);
        }

        private void Start()
        {
            NeedSlider.maxValue = _playerParametersProvider.PlayerParameters.Hunger;
        }
    }
}