using System;
using Cysharp.Threading.Tasks;
using Extensions.UniRX;
using Game.Collectable;
using Game.Player.Models;
using Game.QuestHandler;
using Game.Services.Input;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Pickable
{
    public class ToolCollectableView : MonoBehaviour
    {
        [SerializeField] private EToolType _toolType;
        [SerializeField] private Collider _collectTrigger;
        private IInputProvider _inputProvider;

        private bool _canCollect;
        private readonly CompositeDisposable _disposable = new();
        private ToolsModel _toolsModel;
        private IQuestHandler _questHandler;

        [Inject]
        public void Construct(
            IInputProvider inputProvider,
            ToolsModel toolsModel,
            IQuestHandler questHandler
        )
        {
            _questHandler = questHandler;
            _toolsModel = toolsModel;
            _inputProvider = inputProvider;
        }
        
        public void OnEnable()
        {
            _inputProvider.InputSystem.Player.Interact.ToObservable().Subscribe(_ => TryCollect()).AddTo(_disposable);
            _collectTrigger.OnTriggerEnterAsObservable().Subscribe(_ => _canCollect = true).AddTo(_disposable);
            _collectTrigger.OnTriggerExitAsObservable().Subscribe(_ => _canCollect = false).AddTo(_disposable);
        }

        private void TryCollect()
        {
            if (!_canCollect) 
                return;
            
            switch (_toolType)
            {
                case EToolType.Sword:
                    _questHandler.SwordQuestCompleted.Execute(true);
                    break;
                case EToolType.Pickaxe:
                    _questHandler.PickaxeQuestCompleted.Execute(true);
                    break;
            }
            _toolsModel.Unlock(_toolType);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _disposable?.Dispose();
        }
    }
}