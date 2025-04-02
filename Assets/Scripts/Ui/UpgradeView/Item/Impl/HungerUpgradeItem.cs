using Game.Player.Models;
using Zenject;

namespace Ui.UpgradeView.Item.Impl
{
    public class HungerUpgradeItem : AUpgradeItem
    {
        private HungerModel _hungerModel;

        [Inject]
        private void Construct(HungerModel hungerModel)
        {
            _hungerModel = hungerModel;
        }
        
        protected override float GetCurrentValue()
        {
            return _hungerModel.MaxValue.Value;
        }

        protected override float GetUpgradeAmount()
        {
            return 5f;
        }

        protected override void UpdateModel()
        {
            _hungerModel.MaxValue.Value += (int)GetUpgradeAmount();
        }
    }
}