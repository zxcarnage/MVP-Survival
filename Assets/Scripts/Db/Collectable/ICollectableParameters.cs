using System.Collections.Generic;
using Game.Collectable;

namespace Db.Collectable
{
    public interface ICollectableParameters
    {
        public IReadOnlyDictionary<ECollectableType, float> CollectTime { get; }
    }
}