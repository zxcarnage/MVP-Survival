using Sirenix.OdinInspector;
using UnityEngine;

namespace Db.Camera.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CameraParameters), fileName = nameof(CameraParameters))]
    public class CameraParameters : SerializedScriptableObject, ICameraParameters
    {
        [field: SerializeField] public float Sensitivity { get; private set; }
        
        [field: MinMaxSlider(-90, 90, true)]
        [field: SerializeField]
        public Vector2 MinMaxY { get; private set; }
    }
}