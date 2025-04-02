using System;
using Db.Player;
using Game.Collectable;
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
        private ICollectablePresenter _collectablePresenter;

        private Transform _transform;
        private IPlayerNeedPresenter _playerNeedPresenter;

        [Inject]
        public void Construct(
            MovementDirectionModel movementDirectionModel,
            JumpModel jumpModel,
            IPlayerJumpPresenter playerJumpPresenter,
            IPlayerMovementPresenter playerMovementPresenter,
            ICollectablePresenter collectablePresenter,
            IPlayerParameters playerParameters,
            IPlayerNeedPresenter playerNeedPresenter
        )
        {
            _jumpModel = jumpModel;
            _playerParameters = playerParameters;
            _playerJumpPresenter = playerJumpPresenter;
            _playerMovementPresenter = playerMovementPresenter;
            _movementDirectionModel = movementDirectionModel;
            _collectablePresenter = collectablePresenter;
            _playerNeedPresenter = playerNeedPresenter;
        }

        private void Start()
        {
            _transform = _rigidbody.transform;
            _playerJumpPresenter.Initialize();
            _collectablePresenter.Initialize(_transform);
            _jumpModel.ShouldJump.Subscribe(Jump);
            _playerNeedPresenter.Start();
        }

        private void FixedUpdate()
        {
            _playerMovementPresenter.HandleInput();
            Move();
        }

        private void Move()
        {
            var inputDirection = _movementDirectionModel.Direction;
            var worldDirection = _transform.TransformDirection(inputDirection);
            _rigidbody.velocity = new Vector3(worldDirection.x, _rigidbody.velocity.y, worldDirection.z);
        }

        private void Jump(bool shouldJump)
        {
            if (shouldJump == false)
                return;
            
            _rigidbody.AddForce(Vector3.up * _playerParameters.JumpForce, ForceMode.Impulse);
        }

        private void OnDestroy()
        {
            _playerNeedPresenter.Exit();
        }
    }
}