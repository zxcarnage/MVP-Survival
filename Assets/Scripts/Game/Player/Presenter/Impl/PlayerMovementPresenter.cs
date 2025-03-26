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
        private readonly IPlayerParametersProvider _playerParametersProvider;
        private readonly IInputProvider _inputProvider;

        public PlayerMovementPresenter(
            MovementDirectionModel movementDirectionModel,
            IPlayerParametersProvider playerParametersProvider,
            IInputProvider inputProvider
        )
        {
            _movementDirectionModel = movementDirectionModel;
            _playerParametersProvider = playerParametersProvider;
            _inputProvider = inputProvider;
        }
        
        public void HandleInput()
        {
            var inputDirection = _inputProvider.InputSystem.Player.Move.ReadValue<Vector2>();
            Move(inputDirection);
        }

        private void Move(Vector2 inputDirection)
        {
            var speed = _playerParametersProvider.PlayerParameters.Speed;
            _movementDirectionModel.Direction = new Vector3(inputDirection.x, 0f, inputDirection.y) * speed * Time.deltaTime;
        }
    }
}