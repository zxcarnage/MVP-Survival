using Game.Player.Models;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui.UpgradeView.Item
{
    public abstract class AUpgradeItem : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _currentValueText;
        [SerializeField] private TMP_Text _upgradeAmountText;
        
        private ExperienceModel _experienceModel;

        [Inject]
        private void Construct(ExperienceModel experienceModel)
        {
            _experienceModel = experienceModel;
        }
        
        private void OnEnable()
        {
            _upgradeButton.OnClickAsObservable().Subscribe(Upgrade).AddTo(this);
            _currentValueText.text = $"Current value: {GetCurrentValue()}";
            _upgradeAmountText.text = $"Upgrade amount: {GetUpgradeAmount()}";
        }

        private void Upgrade(Unit unit)
        {
            if (_experienceModel.Level.Value - 1 < 0)
                return;
            UpdateModel();
            _currentValueText.text = $"Current value: {GetCurrentValue()}";
            _upgradeAmountText.text = $"Upgrade amount: {GetUpgradeAmount()}";
            _experienceModel.Level.Value -= 1;
        }

        protected abstract float GetCurrentValue();
        protected abstract float GetUpgradeAmount();
        protected abstract void UpdateModel();
    }
}