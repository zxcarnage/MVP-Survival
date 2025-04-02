using Core.Utils;

namespace Game.Services.SceneLoading
{
    public interface ISceneLoadingManager
    {
        void LoadScene(EGameSceneType gameSceneType);
    }
}