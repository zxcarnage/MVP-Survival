using System.Collections.Generic;
using Game.Player;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CharactersParameters), fileName = nameof(CharactersParameters))]
    public class CharactersParameters : SerializedScriptableObject, ICharactersParameters
    {
        [OdinSerialize] [SerializeField]
        private Dictionary<ECharacters, PlayerParameters> _characters;

        public IReadOnlyDictionary<ECharacters, PlayerParameters> Characters => _characters;
    }
}