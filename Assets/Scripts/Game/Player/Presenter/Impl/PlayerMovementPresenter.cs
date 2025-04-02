using Db.Player;
using Extensions.UniRX;
using Game.Services.Input;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player.Presenter.Impl
{
    public class PlayerMovementPresenter : IPlayerMovementPresenter
    {
        private readonly MovementDirectionModel _movementDirectionModel;
        private readonly IPlayerParameters _playerParameters;
        private readonly IInputProvider _inputProvider;

        public PlayerMovementPresenter(
            MovementDirectionModel movementDirectionModel,
            IPlayerParameters playerParameters,
            IInputProvider inputProvider
        )
        {
            _movementDirectionModel = movementDirectionModel;
            _playerParameters = playerParameters;
            _inputProvider = inputProvider;
        }
        
        public void HandleInput()
        {
            var inputDirection = _inputProvider.InputSystem.Player.Move.ReadValue<Vector2>();
            Move(inputDirection);
        }

        private void Move(Vector2 inputDirection)
        {
            var speed = _playerParameters.Speed;
            _movementDirectionModel.Direction = new Vector3(inputDirection.x, 0f, inputDirection.y) * speed * Time.deltaTime;
        }
    }
}