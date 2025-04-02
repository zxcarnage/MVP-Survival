using Db.Player;
using Extensions.UniRX;
using Game.Player.Presenter.Jump.Model;
using Game.Services.Input;
using UniRx;
using UnityEngine.InputSystem;

namespace Game.Player.Presenter.Jump.Impl
{
    public class PlayerJumpPresenter : IPlayerJumpPresenter
    {
        private readonly IPlayerParameters _playerParameters;
        private readonly IInputProvider _inputProvider;
        private readonly GroundedModule _groundedModule;
        private readonly JumpModel _jumpModel;

        public PlayerJumpPresenter(
            IPlayerParameters playerParameters,
            IInputProvider inputProvider,
            GroundedModule groundedModule,
            JumpModel jumpModel
        )
        {
            _playerParameters = playerParameters;
            _inputProvider = inputProvider;
            _groundedModule = groundedModule;
            _jumpModel = jumpModel;
        }
        
        public void Initialize()
        {
            _inputProvider.InputSystem.Player.Jump.performed += Jump;
            _groundedModule.IsGrounded.Subscribe(Grounded);
        }

        public void Grounded(bool isGrounded)
        {
            _jumpModel.ShouldJump.Value = !isGrounded;
        }
        
        private void Jump(InputAction.CallbackContext input)
        {
            if (_groundedModule.IsGrounded.Value == false)
                return;
            
            _jumpModel.ShouldJump.Value = true;
        }
        
    }
}