using System.Collections.Generic;
using Game.Collectable;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Db.Collectable.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CollectableParameters), fileName = nameof(CollectableParameters))]
    public class CollectableParameters : SerializedScriptableObject, ICollectableParameters
    {
        [field: SerializeField]
        [field: OdinSerialize]
        private Dictionary<ECollectableType, float> _collectTime;
        
        public IReadOnlyDictionary<ECollectableType, float> CollectTime => _collectTime;
        
        [field: SerializeField] public CollectibleVO Watermelon { get; private set; }
        [field: SerializeField] public CollectibleVO Berry { get; private set; }
        [field: SerializeField] public CollectibleVO Coconut { get; private set; }
        [field: SerializeField] public CollectibleVO Meet { get; private set; }
    }
}