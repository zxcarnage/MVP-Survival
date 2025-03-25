using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tools
{
    public class SplashOpener
    {
        [MenuItem("Tools/Open Splash Scene #&s", priority = 1000)]
        public static void OpenSplashScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity", OpenSceneMode.Single);
        }
    }
}