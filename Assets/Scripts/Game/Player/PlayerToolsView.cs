using System.Collections.Generic;
using Game.Collectable;
using Game.Player.Presenter;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerToolsView : SerializedMonoBehaviour
    {
        [SerializeField] private Dictionary<EToolType, GameObject> _typeToObject;
        
        private IPlayerToolsPresenter _playerToolsPresenter;

        [Inject]
        public void Construct(
            IPlayerToolsPresenter playerToolsPresenter
        )
        {
            _playerToolsPresenter = playerToolsPresenter;
        }
        
        public void UpdateView(EToolType currentType, EToolType targetType)
        {
            _typeToObject[currentType]?.SetActive(false);
            _typeToObject[targetType]?.SetActive(true);
        }

        private void OnEnable()
        {
            _playerToolsPresenter.Enable(this);
        }

        private void OnDisable()
        {
            _playerToolsPresenter.Disable();
        }
    }
}