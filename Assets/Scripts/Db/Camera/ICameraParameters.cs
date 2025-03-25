using UnityEngine;

namespace Db.Camera
{
    public interface ICameraParameters
    {
        public float Sensitivity { get; }
        public Vector2 MinMaxY { get; }
    }
}