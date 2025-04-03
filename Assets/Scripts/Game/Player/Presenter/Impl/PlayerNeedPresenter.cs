using Db.Player;
using DG.Tweening;
using Game.Player.Models;
using Game.Providers;
using Game.Services.Needs;
using UnityEngine;

namespace Game.Player.Presenter.Impl
{
    public class PlayerNeedPresenter : IPlayerNeedPresenter
    {
        private readonly INeedService _needService;
        private readonly IPlayerParametersProvider _playerParametersProvider;
        private readonly DrinkerModel _drinkerModel;
        private readonly MetabolismModel _metabolismModel;

        private Tween _needTween;

        public PlayerNeedPresenter(
            INeedService needService,
            IPlayerParametersProvider playerParametersProvider,
            DrinkerModel drinkerModel,
            MetabolismModel metabolismModel
        )
        {
            _needService = needService;
            _playerParametersProvider = playerParametersProvider;
            _drinkerModel = drinkerModel;
            _metabolismModel = metabolismModel;
        }

        public void Start()
        {
            var playerParameters = _playerParametersProvider.PlayerParameters;
            _needTween = DOVirtual.DelayedCall(playerParameters.NeedDecreaseDelay,DecreaseNeeds, false).SetLoops(-1);
        }

        private void DecreaseNeeds()
        {
            Debug.Log($"DecreaseNeeds {_metabolismModel.SkillLevel.Value} \n {_drinkerModel.Level.Value}");
            var decreaseHungerValue = 5 - 0.3f * (_metabolismModel.SkillLevel.Value - 1);
            var decreaseWaterValue = 5 - 0.2f * (_drinkerModel.Level.Value - 1);
            _needService.DecreaseNeed(decreaseWaterValue, ENeedType.Water);
            _needService.DecreaseNeed(decreaseHungerValue, ENeedType.Hunger);
        }

        public void Exit()
        {
            _needTween?.Kill();
        }
    }
}