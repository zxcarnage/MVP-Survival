using Db.Player;
using DG.Tweening;
using Game.Services.Needs;

namespace Game.Player.Presenter.Impl
{
    public class PlayerNeedPresenter : IPlayerNeedPresenter
    {
        private readonly INeedService _needService;
        private readonly IPlayerParameters _playerParameters;

        private Tween _needTween;

        public PlayerNeedPresenter(
            INeedService needService,
            IPlayerParameters playerParameters
        )
        {
            _needService = needService;
            _playerParameters = playerParameters;
        }

        public void Start()
        {
            _needTween = DOVirtual.DelayedCall(_playerParameters.NeedDecreaseDelay,DecreaseNeeds, false).SetLoops(-1);
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