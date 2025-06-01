using Core.ScenesBase;
using Core.Utils;
using Extensions.UniRX;
using Game.Services.Input;
using Game.Services.SceneLoading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Ship.Impl
{
    public class ShipMovableView : MonoBehaviour
    {
        [SerializeField] private Collider _leaveIslandTrigger;
        
        private readonly CompositeDisposable _disposable = new();
        private IInputProvider _inputProvider;
        private bool _canInteract;
        private ISceneLoadingManager _sceneLoadingManager;

        [Inject]
        public void Construct(
            IInputProvider inputProvider,
            ISceneLoadingManager sceneLoadingManager
        )
        {
            _sceneLoadingManager = sceneLoadingManager;
            _inputProvider = inputProvider;
        }
        
        public void OnEnable()
        {
            _inputProvider.InputSystem.Player.Interact.ToObservable().Subscribe(_ => TryLeave()).AddTo(_disposable);
            _leaveIslandTrigger.OnTriggerEnterAsObservable().Subscribe(_ => _canInteract = true).AddTo(_disposable);
            _leaveIslandTrigger.OnTriggerExitAsObservable().Subscribe(_ => _canInteract = false).AddTo(_disposable);
        }

        private void TryLeave()
        {
            if (!_canInteract)
                return;

            _sceneLoadingManager.LoadScene(EGameSceneType.MainMenu);
        }
        
        private void OnDisable()
        {
            _disposable?.Dispose();
        }
    }
}