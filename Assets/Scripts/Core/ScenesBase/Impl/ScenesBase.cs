using System;
using System.Collections.Generic;
using Core.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Core.ScenesBase.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ScenesBase), fileName = nameof(ScenesBase))]
    public class ScenesBase : SerializedScriptableObject, IScenesBase
    {
        [OdinSerialize] private Dictionary<EGameSceneType, ScenesRef> _sceneRefs;

        private void OnValidate()
        {
            foreach (var sceneRef in _sceneRefs.Values)
                sceneRef.Init();
        }

        public string GetSceneNameByType(EGameSceneType sceneType)
        {
            if (!_sceneRefs.TryGetValue(sceneType, out var sceneRef))
                throw new Exception($"Scene {sceneType} not found! Fill " + nameof(ScenesBase) + " with scenes");
            
            return sceneRef.SceneName; 
        }
    }
}