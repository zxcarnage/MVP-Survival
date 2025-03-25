using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerParameters), fileName = nameof(PlayerParameters))]
    public class PlayerParameters : ScriptableObject, IPlayerParameters
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}