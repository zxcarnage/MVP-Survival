using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Ui.Quests.Impl
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _dialogueGroup;
        [SerializeField] private TMP_Text _questText;
        private IQuestPresenter _questPresenter;

        [Inject]
        private void Construct(IQuestPresenter questPresenter)
        {
            _questPresenter = questPresenter;
        }

        private void OnEnable()
        {
            _dialogueGroup.alpha = 1f;
            _questPresenter.Enable(this);
        }

        public void UpdateView(string newQuest)
        {
            _questText.text = newQuest;
        }
    }
}