using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Tools
{
    public class SplashOpener
    {
#if UNITY_EDITOR
        [MenuItem("Tools/Open Splash Scene #&s", priority = 1000)]
        public static void OpenSplashScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity", OpenSceneMode.Single);
        }
#endif
    }
}