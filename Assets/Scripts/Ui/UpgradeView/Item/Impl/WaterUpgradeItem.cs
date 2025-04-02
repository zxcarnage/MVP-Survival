using Game.Player.Models;
using Zenject;

namespace Ui.UpgradeView.Item.Impl
{
    public class WaterUpgradeItem : AUpgradeItem
    {
        private WaterModel _waterModel;

        [Inject]
        public void Construct(WaterModel waterModel)
        {
            _waterModel = waterModel;
        }
        
        protected override float GetCurrentValue()
        {
            return _waterModel.MaxValue.Value;
        }

        protected override float GetUpgradeAmount()
        {
            return 5f;
        }

        protected override void UpdateModel()
        {
            _waterModel.MaxValue.Value +=(int)GetUpgradeAmount();
        }
    }
}