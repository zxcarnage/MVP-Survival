using Game.Player.Models;
using Zenject;

namespace Ui.UpgradeView.Item.Impl
{
    public class LuckUpgradeItem : AUpgradeItem
    {
        private LuckModel _luckModel;

        [Inject]
        public void Construct(LuckModel luckModel)
        {
            _luckModel = luckModel;
        }
        protected override float GetCurrentValue()
        {
            return _luckModel.MaxValue.Value;
        }

        protected override float GetUpgradeAmount()
        {
            return 0.01f;
        }

        protected override void UpdateModel()
        {
            _luckModel.MaxValue.Value += GetUpgradeAmount();
        }
    }
}