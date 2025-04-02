using Core.ScenesBase;
using Core.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Services.SceneLoading.Impl
{
    public class SceneLoadingManager : ISceneLoadingManager
    {
        private readonly IScenesBase _scenesBase;

        public SceneLoadingManager(
            IScenesBase scenesBase
        )
        {
            _scenesBase = scenesBase;
        }
        
        public void LoadScene(EGameSceneType gameSceneType)
        {
            var targetScene = _scenesBase.GetSceneNameByType(gameSceneType);
            SceneManager.LoadSceneAsync(targetScene);
        }
    }
}