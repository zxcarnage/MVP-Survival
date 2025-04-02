using Db.CharacterChoose;
using Db.Player.Impl;
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

        [Inject]
        private void Construct(ICharacterChooseParameters characterChooseParameters)
        {
            CharacterChooseParameters = characterChooseParameters;
        }

        private void Start()
        {
            _arrowButton = GetComponent<Button>();
            _arrowButton.OnClickAsObservable().Subscribe(ChangeStats).AddTo(this);
        }

        private void ChangeStats(Unit unit)
        {
            _targetImage.texture = TargetRenderTexture;
            _hpText.text = _playerParameters.Health.ToString();
            _waterText.text = _playerParameters.Water.ToString();
            _hungerText.text = _playerParameters.Hunger.ToString();
            _luckText.text = _playerParameters.Luck.ToString();
            //TODO: PROVIDER REPLACE
        }
    }
}