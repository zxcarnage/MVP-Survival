using Cysharp.Threading.Tasks;
using Db.Collectable;
using Game.Player.Models;
using Game.Services.Input;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Collectable
{
    public class CollectablePresenter : ICollectablePresenter
    {
        private readonly ICollectableParameters _collectableParameters;
        private readonly IInputProvider _inputProvider;
        private readonly InventoryModel _inventoryModel;
        private readonly LuckModel _luckModel;
        private bool _taskRunning = false;
        private readonly ExperienceModel _experienceModel;

        public CollectablePresenter(
            ICollectableParameters collectableParameters,
            IInputProvider inputProvider,
            InventoryModel inventoryModel,
            LuckModel luckModel,
            ExperienceModel experienceModel
        )
        {
            _experienceModel = experienceModel;
            _collectableParameters = collectableParameters;
            _inputProvider = inputProvider;
            _inventoryModel = inventoryModel;
            _luckModel = luckModel;
        }

        public void Initialize(Transform player)
        {
            _inputProvider.InputSystem.Player.Interact.performed += _ => TryCollect(player);
        }
        
        private void TryCollect(Transform player)
        {
            if (_taskRunning)
                return;
            var ray = new Ray(player.position, UnityEngine.Camera.main.transform.forward);
            Debug.Log($"Ray {ray}");
            if (Physics.Raycast(ray, out var other, 40f, 1 << 6) == false)
                return;
            
            if (other.collider.TryGetComponent(out ICollectable collectable) == false)
                return;

            var type = collectable.ECollectableType;
            
            var delay = _collectableParameters.CollectTime[type];
            CollectAsync(type, delay, other.collider).Forget();
        }

        private async UniTaskVoid CollectAsync(ECollectableType type, float collectTime, Collider other)
        {
            _taskRunning = true;
            await UniTask.WaitForSeconds(collectTime);
            
            _inventoryModel.Inventory[type]++;
            _experienceModel.Level.Value++;
            Object.Destroy(other.gameObject);
            _taskRunning = false;
            TryCollectAdditional(type);
        }

        private void TryCollectAdditional(ECollectableType type)
        {
            var basicAmountPercent = Random.Range(0, 1f);
            var basicAmount = Mathf.RoundToInt(basicAmountPercent);
            var maxBonus = 10f;
            var sigmoid = maxBonus / (basicAmount + Mathf.Exp(-20f * (_luckModel.Value.Value - 0.5f)));
            int additionalResources = basicAmount + Mathf.RoundToInt(sigmoid);
            
            Debug.Log($"Additional {additionalResources}");
            switch (type)
            {
                case ECollectableType.Grass:
                    _inventoryModel.Inventory[ECollectableType.Berry]+= additionalResources;
                    break;
                case ECollectableType.Wood:
                    _inventoryModel.Inventory[ECollectableType.Coconut]+= additionalResources;
                    break;
                case ECollectableType.Watermelon:
                    _inventoryModel.Inventory[ECollectableType.Watermelon]+= additionalResources;
                    break;

            }
        }
    }
}