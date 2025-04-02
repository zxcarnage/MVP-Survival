using Db.Player;
using DG.Tweening;
using Game.Providers;
using Game.Services.Needs;

namespace Game.Player.Presenter.Impl
{
    public class PlayerNeedPresenter : IPlayerNeedPresenter
    {
        private readonly INeedService _needService;
        private readonly IPlayerParametersProvider _playerParametersProvider;

        private Tween _needTween;

        public PlayerNeedPresenter(
            INeedService needService,
            IPlayerParametersProvider playerParametersProvider
        )
        {
            _needService = needService;
            _playerParametersProvider = playerParametersProvider;
        }

        public void Start()
        {
            var playerParameters = _playerParametersProvider.PlayerParameters;
            _needTween = DOVirtual.DelayedCall(playerParameters.NeedDecreaseDelay,DecreaseNeeds, false).SetLoops(-1);
        }

        private void DecreaseNeeds()
        {
            _needService.DecreaseNeed(1, ENeedType.Water);
            _needService.DecreaseNeed(1, ENeedType.Hunger);
        }

        public void Exit()
        {
            _needTween?.Kill();
        }
    }
}