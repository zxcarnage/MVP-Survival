using Game.Player;
using Game.Player.Models;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.SkillPoints
{
    public class SkillPointsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private SkillPointsModel _skillPointsModel;

        [Inject]
        public void Construct(
            SkillPointsModel skillPointsModel
        )
        {
            _skillPointsModel = skillPointsModel;
        }
        
        
        private void Awake()
        {
            _skillPointsModel.Amount.Subscribe(UpdateView);
        }

        private void UpdateView(int newValue)
        {
            _text.text = $"Skillpoint: {newValue}";
        }
    }
}