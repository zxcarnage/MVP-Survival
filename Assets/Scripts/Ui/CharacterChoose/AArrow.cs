using Db.CharacterChoose;
using Db.Player.Impl;
using Game.Providers;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui.CharacterChoose
{
    public abstract class AArrow : MonoBehaviour
    {
        [SerializeField] private RawImage _targetImage;
        [SerializeField] private TMP_Text _hpText;
        [SerializeField] private TMP_Text _waterText;
        [SerializeField] private TMP_Text _hungerText;
        [SerializeField] private TMP_Text _luckText;
        [SerializeField] private PlayerParameters _playerParameters;
        protected ICharacterChooseParameters CharacterChooseParameters;
        
        protected abstract RenderTexture TargetRenderTexture { get; }

        private Button _arrowButton;
        private IPlayerParametersProvider _playerParametersProvider;

        [Inject]
        private void Construct(
            ICharacterChooseParameters characterChooseParameters,
            IPlayerParametersProvider playerParametersProvider
        )
        {
            CharacterChooseParameters = characterChooseParameters;
            _playerParametersProvider = playerParametersProvider;
        }

        private void Start()
        {
            _arrowButton = GetComponent<Button>();
            _arrowButton.OnClickAsObservable().Subscribe(ChangeStats).AddTo(this);
        }

        public void ChangeStats(Unit unit)
        {
            _targetImage.texture = TargetRenderTexture;
            _hpText.text = $"HP: {_playerParameters.Health}";
            _waterText.text = $"Water: {_playerParameters.Water}";
            _hungerText.text = $"Hunger: {_playerParameters.Hunger}";
            _luckText.text = $"Luck: {_playerParameters.Luck}";
            _playerParametersProvider.ChangeParameters(_playerParameters);
        }
    }
}