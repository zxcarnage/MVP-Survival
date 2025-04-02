using System.Collections.Generic;
using Game.Collectable;

namespace Db.Collectable
{
    public interface ICollectableParameters
    {
        public IReadOnlyDictionary<ECollectableType, float> CollectTime { get; }
        
        public CollectibleVO Watermelon { get; }
        public CollectibleVO Berry { get; }
        public CollectibleVO Coconut { get; }
        public CollectibleVO Meet { get; }
    }
}