using Game.Player.Models;
using Zenject;

namespace Ui.UpgradeView.Item.Impl
{
    public class MetabolismUpgrade : AUpgradeItem
    {
        private MetabolismModel _metabolismModel;
        
        [Inject]
        public void Construct(MetabolismModel metabolismModel)
        {
            _metabolismModel = metabolismModel;
        }
        
        protected override float GetCurrentValue()
        {
            return _metabolismModel.SkillLevel.Value;
        }

        protected override float GetUpgradeAmount()
        {
            return 1f;
        }

        protected override void UpdateModel()
        {
            _metabolismModel.SkillLevel.Value += (int)GetUpgradeAmount();
        }
    }
}