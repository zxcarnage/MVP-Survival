using UnityEngine;

namespace Game.Player.Presenter
{
    public class PlayerMovementPresenter : IPlayerMovementPresenter
    {
        private readonly IPlayerView _playerView;
        private readonly MovementDirectionModel _movementDirectionModel;

        public PlayerMovementPresenter(
            IPlayerView playerView,
            MovementDirectionModel movementDirectionModel)
        {
            _playerView = playerView;
            _movementDirectionModel = movementDirectionModel;
        }

        public void HandleInput()
        {
            var inputDirection = _movementDirectionModel.Direction;
            var transform = _playerView.GetTransform();
            var worldDirection = transform.TransformDirection(inputDirection);
            var currentVelocity = new Vector3(worldDirection.x, _playerView.GetTransform().GetComponent<Rigidbody>().velocity.y, worldDirection.z);
            
            _playerView.SetVelocity(currentVelocity);
        }
    }
} 