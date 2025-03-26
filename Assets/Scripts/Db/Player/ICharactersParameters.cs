using System.Collections.Generic;
using Db.Player.Impl;
using Game.Player;

namespace Db.Player
{
    public interface ICharactersParameters
    {
        IReadOnlyDictionary<ECharacters, PlayerParameters> Characters { get; }
    }
}