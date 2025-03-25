using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = System.Object;

namespace Core.Utils
{
    [Serializable]
    [HideReferenceObjectPicker]
    public class ScenesRef
    {
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.SceneAsset _sceneAsset;
#endif
        [SerializeField, HideInInspector] private string _sceneName;

        public string SceneName => _sceneName;

        public ScenesRef()
        {

        }

        public ScenesRef(string sceneName)
        {
            this._sceneName = sceneName;

#if UNITY_EDITOR
            _sceneAsset = null;
#endif
        }

        public static implicit operator ScenesRef(string sceneName) => new ScenesRef(sceneName);

        public void Init()
        {
#if UNITY_EDITOR
            if (_sceneAsset == default(Object))
            {
                _sceneName = null;
                return;
            }

            var path = UnityEditor.AssetDatabase.GetAssetPath(_sceneAsset);

            var name = path
                .Split('/')
                .Last()
                .Split('.')
                .First();

            _sceneName = name;
#endif
        }
    }
}