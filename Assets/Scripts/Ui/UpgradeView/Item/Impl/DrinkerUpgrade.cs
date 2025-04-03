using Game.Player.Models;
using Zenject;

namespace Ui.UpgradeView.Item.Impl
{
    public class DrinkerUpgrade : AUpgradeItem
    {
        private DrinkerModel _drinkerUpgrade;
        
        [Inject]
        public void Construct(DrinkerModel drinkerUpgrade)
        {
            _drinkerUpgrade = drinkerUpgrade;
        }
        
        protected override float GetCurrentValue()
        {
            return _drinkerUpgrade.Level.Value;
        }

        protected override float GetUpgradeAmount()
        {
            return 1f;
        }

        protected override void UpdateModel()
        {
            _drinkerUpgrade.Level.Value += (int)GetUpgradeAmount();
        }
    }
}