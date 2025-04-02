using Game.Player;
using Game.Player.Models;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private ExperienceModel _experienceModel;

        [Inject]
        public void Construct(
            ExperienceModel experienceModel
        )
        {
            _experienceModel = experienceModel;
        }
        
        
        private void Awake()
        {
            _experienceModel.Level.Subscribe(UpdateView);
        }

        private void UpdateView(int newValue)
        {
            _text.text = $"Level: {newValue}";
        }
    }
}