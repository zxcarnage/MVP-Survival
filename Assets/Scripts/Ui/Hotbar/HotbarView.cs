using System;
using Cysharp.Threading.Tasks;
using Extensions.UniRX;
using Game.Collectable;
using Game.Services.Input;
using Game.Services.Inventory;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.Hotbar
{
    public class HotbarView: MonoBehaviour
    {
        private IInputProvider _inputProvider;
        private IInventoryService _inventoryService;

        [Inject]
        private void Construct(
            IInputProvider inputProvider,
            IInventoryService inventoryService
        )
        {
            _inventoryService = inventoryService;
            _inputProvider = inputProvider;
        }
        private void OnEnable()
        {
            _inputProvider.InputSystem.Player.Item1.ToObservable().Subscribe(_ => UseItem(1)).AddTo(this);
            _inputProvider.InputSystem.Player.Item2.ToObservable().Subscribe(_ => UseItem(2)).AddTo(this);
            _inputProvider.InputSystem.Player.Item3.ToObservable().Subscribe(_ => UseItem(3)).AddTo(this);
            _inputProvider.InputSystem.Player.Item4.ToObservable().Subscribe(_ => UseItem(4)).AddTo(this);
        }

        private void UseItem(int index)
        {
            switch (index)
            {
                case 1:
                    _inventoryService.ActivateCollectable(ECollectableType.Watermelon);
                    break;
                case 2:
                    _inventoryService.ActivateCollectable(ECollectableType.Berry);
                    break;
                case 3:
                    _inventoryService.ActivateCollectable(ECollectableType.Coconut);
                    break;
                case 4:
                    _inventoryService.ActivateCollectable(ECollectableType.Meet);
                    break;
            }
        }
    }
}