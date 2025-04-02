using Core.Utils;
using Game.Services.SceneLoading;
using UniRx;
using Zenject;

namespace Ui.MainMenu.Impl
{
    public class PlayButton : AButton
    {
        private ISceneLoadingManager _sceneLoadingManager;

        [Inject]
        private void Construct(ISceneLoadingManager sceneLoadingManager)
        {
            _sceneLoadingManager = sceneLoadingManager;
        }
        
        protected override void OnAction(Unit unit)
        {
            _sceneLoadingManager.LoadScene(EGameSceneType.CharacterChoose);
        }
    }
}