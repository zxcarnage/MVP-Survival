using Db.Player;
using Game.Player;

namespace Game.Services.ChooseCharacter.Impl
{
    public class ChooseCharacterService : IChooseCharacterService
    {
        private readonly IPlayerParametersProvider _playerParametersProvider;
        private readonly ICharactersParameters _charactersParameters;

        public ChooseCharacterService(
            IPlayerParametersProvider playerParametersProvider,
            ICharactersParameters charactersParameters
        )
        {
            _playerParametersProvider = playerParametersProvider;
            _charactersParameters = charactersParameters;
        }
        
        public void Choose(ECharacters character)
        {
            var targetParameters = _charactersParameters.Characters[character];
            _playerParametersProvider.SetPlayerParameters(targetParameters);
        }
    }
}