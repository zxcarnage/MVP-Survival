using Db.Player.Impl;

namespace Game.Providers
{
    public interface IPlayerParametersProvider
    {
        PlayerParameters PlayerParameters { get; }
        
        public void ChangeParameters(PlayerParameters playerParameters);
    }
}