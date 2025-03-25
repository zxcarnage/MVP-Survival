using System;
using Db.Player;
using Game.Player.Presenter;
using Game.Player.Presenter.Jump;
using Game.Player.Presenter.Jump.Model;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private MovementDirectionModel _movementDirectionModel;
        private IPlayerMovementPresenter _playerMovementPresenter;
        private IPlayerJumpPresenter _playerJumpPresenter;
        private JumpModel _jumpModel;
        private IPlayerParameters _playerParameters;

        [Inject]
        public void Construct(
            MovementDirectionModel movementDirectionModel,
            JumpModel jumpModel,
            IPlayerJumpPresenter playerJumpPresenter,
            IPlayerMovementPresenter playerMovementPresenter,
            IPlayerParameters playerParameters
        )
        {
            _jumpModel = jumpModel;
            _playerParameters = playerParameters;
            _playerJumpPresenter = playerJumpPresenter;
            _playerMovementPresenter = playerMovementPresenter;
            _movementDirectionModel = movementDirectionModel;
        }

        private void Start()
        {
            _playerJumpPresenter.Initialize();
            _jumpModel.ShouldJump.Subscribe(Jump);
        }

        private void FixedUpdate()
        {
            _playerMovementPresenter.HandleInput();
            Move();
        }

        private void Move()
        {
            var inputDirection = _movementDirectionModel.Direction;
            var worldDirection = _rigidbody.transform.TransformDirection(inputDirection);
            _rigidbody.velocity = new Vector3(worldDirection.x, _rigidbody.velocity.y, worldDirection.z);
        }

        private void Jump(bool shouldJump)
        {
            if (shouldJump == false)
                return;
            
            _rigidbody.AddForce(Vector3.up * _playerParameters.JumpForce, ForceMode.Impulse);
        }
    }
}