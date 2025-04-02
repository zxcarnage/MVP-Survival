using Game.Player;
using Game.Player.Models;
using UniRx;
using Zenject;

namespace Game.Services.Skill
{
    public class SkillService : IInitializable
    {
        private readonly ExperienceModel _experienceModel;
        private readonly SkillPointsModel _skillPointsModel;

        private int _previousLevel = 0;

        public SkillService(
            ExperienceModel experienceModel,
            SkillPointsModel skillPointsModel
        )
        {
            _experienceModel = experienceModel;
            _skillPointsModel = skillPointsModel;
        }

        public void Initialize()
        {
            _experienceModel.Level.Subscribe(AddSkillPoint);
        }

        private void AddSkillPoint(int level)
        {
            var skillPointAmount = level - _previousLevel;
            _previousLevel = level;
            _skillPointsModel.Amount.Value += skillPointAmount;
        }
    }
}