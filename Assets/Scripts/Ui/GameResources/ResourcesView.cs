using System;
using Game.Collectable;
using Game.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.GameResources
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private ECollectableType _type;
        [SerializeField] private TMP_Text _text;
        private InventoryModel _inventoryModel;

        [Inject]
        public void Construct(
            InventoryModel inventoryModel
        )
        {
            _inventoryModel = inventoryModel;
        }
        
        private void Awake()
        {
            _inventoryModel.Inventory.ObserveReplace().Subscribe(UpdateView);
        }

        private void UpdateView(DictionaryReplaceEvent<ECollectableType, int> evt)
        {
            if (evt.Key == _type)
                _text.text = evt.NewValue.ToString();
        }
    }
}