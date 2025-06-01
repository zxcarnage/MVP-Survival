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
        private const int COLLECTABLE_LAYER = 6;
        private const float RAYCAST_DISTANCE = 40f;
        
        private readonly ICollectableParameters _collectableParameters;
        private readonly IInputProvider _inputProvider;
        private readonly InventoryModel _inventoryModel;
        private readonly LuckModel _luckModel;
        private readonly ToolsModel _toolsModel;
        private readonly ExperienceModel _experienceModel;
        
        private bool _isCollecting;

        public CollectablePresenter(
            ICollectableParameters collectableParameters,
            IInputProvider inputProvider,
            InventoryModel inventoryModel,
            LuckModel luckModel,
            ToolsModel toolsModel,
            ExperienceModel experienceModel
        )
        {
            _experienceModel = experienceModel;
            _collectableParameters = collectableParameters;
            _inputProvider = inputProvider;
            _inventoryModel = inventoryModel;
            _luckModel = luckModel;
            _toolsModel = toolsModel;
        }

        public void Initialize(Transform player)
        {
            _inputProvider.InputSystem.Player.Interact.performed += _ => TryCollect(player);
        }
        
        private void TryCollect(Transform player)
        {
            if (ShouldSkipCollection())
                return;
            
            var ray = CreateRayFromPlayer(player);
            if (!TryGetCollectable(ray, out var collectable))
                return;

            var collectableType = collectable.ECollectableType;
            if (!IsCorrectToolForCollectable(collectableType))
                return;

            StartCollection(collectableType, collectable);
        }

        private bool ShouldSkipCollection()
        {
            return _isCollecting || _toolsModel.ActiveTool.Value is EToolType.None;
        }

        private static Ray CreateRayFromPlayer(Transform player)
        {
            return new Ray(player.position, UnityEngine.Camera.main!.transform.forward);
        }

        private bool TryGetCollectable(Ray ray, out ICollectable collectable)
        {
            collectable = null;
            return Physics.Raycast(ray, out var hitInfo, RAYCAST_DISTANCE, 1 << COLLECTABLE_LAYER) 
                   && hitInfo.collider.TryGetComponent(out collectable);
        }

        private bool IsCorrectToolForCollectable(ECollectableType collectableType)
        {
            var activeTool = _toolsModel.ActiveTool.Value;
            return (activeTool != EToolType.Pickaxe || collectableType == ECollectableType.Rock) &&
                   (activeTool != EToolType.Sword || collectableType != ECollectableType.Rock);
        }

        private void StartCollection(ECollectableType collectableType, ICollectable collectable)
        {
            var delay = _collectableParameters.CollectTime[collectableType];
            CollectAsync(collectableType, delay, collectable).Forget();
        }

        private async UniTaskVoid CollectAsync(ECollectableType type, float collectTime, ICollectable collectable)
        {
            _isCollecting = true;
            await UniTask.WaitForSeconds(collectTime);
            
            ProcessCollection(type, collectable);
            _isCollecting = false;
            
            ProcessAdditionalResources(type);
        }

        private void ProcessCollection(ECollectableType type, ICollectable collectable)
        {
            _inventoryModel.ConsumableInventory[type]++;
            _experienceModel.Level.Value++;
            
            if (collectable is MonoBehaviour behaviour)
            {
                Object.Destroy(behaviour.gameObject);
            }
        }

        private void ProcessAdditionalResources(ECollectableType type)
        {
            var additionalAmount = CalculateAdditionalResources();
            AddAdditionalResources(type, additionalAmount);
        }

        private int CalculateAdditionalResources()
        {
            var baseAmount = Mathf.RoundToInt(Random.Range(0, 1f));
            const float MAX_BONUS = 10f;
            var luckFactor = MAX_BONUS / (baseAmount + Mathf.Exp(-20f * (_luckModel.Value.Value - 0.5f)));
            
            return baseAmount + Mathf.RoundToInt(luckFactor);
        }

        private void AddAdditionalResources(ECollectableType type, int amount)
        {
            var resourceType = GetAdditionalResourceType(type);
            if (resourceType != null)
            {
                _inventoryModel.ConsumableInventory[resourceType.Value] += amount;
            }
        }

        private static ECollectableType? GetAdditionalResourceType(ECollectableType type)
        {
            return type switch
            {
                ECollectableType.Grass => ECollectableType.Berry,
                ECollectableType.Wood => ECollectableType.Coconut,
                ECollectableType.Watermelon => ECollectableType.Watermelon,
                _ => null
            };
        }
    }
}