using UnityEngine;

namespace Game.Collectable
{
    public class Collectable : MonoBehaviour, ICollectable
    {
        [field: SerializeField] public ECollectableType ECollectableType { get; private set; }
    }
}