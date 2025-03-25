using Core.ScenesBase;
using Core.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Services.SceneLoading.Impl
{
    public class SceneLoadingManager : ISceneLoadingManager
    {
        private const EGameSceneType START_SCENE = EGameSceneType.Main;
        private const EGameSceneType LOADING_SCENE = EGameSceneType.Main;
        
        private readonly IScenesBase _scenesBase;

        private string StartSceneName => _scenesBase.GetSceneNameByType(START_SCENE);
        private string LoadingSceneName => _scenesBase.GetSceneNameByType(LOADING_SCENE);

        public SceneLoadingManager(
            IScenesBase scenesBase
        )
        {
            _scenesBase = scenesBase;
        }
        
        public void LoadGameFromSplash()
        {
            LoadWithSceneBetween(LoadingSceneName, StartSceneName).Forget();
        }

        private static async UniTaskVoid LoadWithSceneBetween(string loadingScene, string sceneToLoad)
        {
            SceneManager.LoadSceneAsync(loadingScene);
            await SceneManager.LoadSceneAsync(sceneToLoad).ToUniTask();
        }
    }
}