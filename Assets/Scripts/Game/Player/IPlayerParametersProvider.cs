using Db.Player.Impl;

namespace Game.Player
{
    public interface IPlayerParametersProvider
    {
        public PlayerParameters PlayerParameters { get; }
        
        void SetPlayerParameters(PlayerParameters parameters);
    }
}