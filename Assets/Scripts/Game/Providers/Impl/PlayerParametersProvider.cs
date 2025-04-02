using Db.Player.Impl;

namespace Game.Providers.Impl
{
    public class PlayerParametersProvider : IPlayerParametersProvider
    {
        private PlayerParameters _playerParameters;
        
        public PlayerParameters PlayerParameters => _playerParameters;
        
        public void ChangeParameters(PlayerParameters playerParameters) => _playerParameters = playerParameters;
    }
}