using Extensions.UniRX;
using Game.Collectable;
using Game.Player.Models;
using Game.Services.Input;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Ship.Impl
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private Collider _buildTrigger;
        [SerializeField] private GameObject _inactiveShip;
        [SerializeField] private GameObject _activeShip;

        
        private readonly CompositeDisposable _disposable = new();
        private bool _canInteract;
        private IInputProvider _inputProvider;
        private InventoryModel _inventoryModel;
        private IShipPresenter _shipPresenter;

        [Inject]
        public void Construct(
            IInputProvider inputProvider,
            InventoryModel inventoryModel,
            IShipPresenter shipPresenter
        )
        {
            _shipPresenter = shipPresenter;
            _inventoryModel = inventoryModel;
            _inputProvider = inputProvider;
        }

        public void OnEnable()
        {
            _inputProvider.InputSystem.Player.Interact.ToObservable().Subscribe(_ => TryBuild()).AddTo(_disposable);
            _buildTrigger.OnTriggerEnterAsObservable().Subscribe(_ => _canInteract = true).AddTo(_disposable);
            _buildTrigger.OnTriggerExitAsObservable().Subscribe(_ => _canInteract = false).AddTo(_disposable);
        }

        private void TryBuild()
        {
            if (!IsEnoughResources() || !_canInteract)
                return;
            
            _shipPresenter.Build(_inactiveShip, _activeShip);
            
            return;

            bool IsEnoughResources()
            {
                return _inventoryModel.ConsumableInventory[ECollectableType.Wood] >= 10 &&
                       _inventoryModel.ConsumableInventory[ECollectableType.Rock] >= 5;
            }
        }
        
        private void OnDisable()
        {
            _disposable?.Dispose();
        }
    }
}