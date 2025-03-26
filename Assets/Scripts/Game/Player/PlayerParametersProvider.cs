using Db.Player.Impl;

namespace Game.Player
{
    public class PlayerParametersProvider : IPlayerParametersProvider
    {
        public PlayerParameters PlayerParameters { get; private set; }

        public PlayerParametersProvider(
            PlayerParameters playerParameters
        )
        {
            SetPlayerParameters(playerParameters);
        }

        public void SetPlayerParameters(PlayerParameters parameters)
        {
            PlayerParameters = parameters;
        }
    }
}