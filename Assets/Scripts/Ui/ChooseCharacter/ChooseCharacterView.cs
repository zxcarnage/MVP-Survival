using Game.Player;
using Game.Services.ChooseCharacter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui.ChooseCharacter
{
    public class ChooseCharacterView : MonoBehaviour
    {
        [SerializeField] private ECharacters _targetCharacter;
        [SerializeField] private Button _chooseButton;
        
        private IChooseCharacterService _chooseCharacterService;

        [Inject]
        public void Construct(
            IChooseCharacterService chooseCharacterService
        )
        {
            _chooseCharacterService = chooseCharacterService;
        }
        private void OnEnable()
        {
            _chooseButton.OnClickAsObservable().Subscribe(_ => OnChosen()).AddTo(this);
        }

        private void OnChosen()
        {
            _chooseCharacterService.Choose(_targetCharacter);
        }
    }
}