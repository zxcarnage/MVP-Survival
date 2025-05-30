using UnityEngine;

namespace Game.Player
{
    public interface IPlayerView
    {
        void SetVelocity(Vector3 velocity);
        void ApplyJumpForce(float force);
        Transform GetTransform();
        void Initialize();
    }
} 