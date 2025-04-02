using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerParameters), fileName = nameof(PlayerParameters))]
    public class PlayerParameters : ScriptableObject, IPlayerParameters
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Water { get; private set; }
        [field: SerializeField] public int Hunger { get; private set; }
        [field: SerializeField] public float Luck { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public float NeedDecreaseDelay { get; private set; }
    }
}