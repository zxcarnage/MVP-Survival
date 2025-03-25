using System;
using Db.Player;
using Game.Player.Presenter;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private MovementDirectionModel _movementDirectionModel;
        private IPlayerMovementPresenter _playerMovementPresenter;

        [Inject]
        public void Construct(
            MovementDirectionModel movementDirectionModel,
            IPlayerMovementPresenter playerMovementPresenter
        )
        {
            _playerMovementPresenter = playerMovementPresenter;
            _movementDirectionModel = movementDirectionModel;
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
    }
}