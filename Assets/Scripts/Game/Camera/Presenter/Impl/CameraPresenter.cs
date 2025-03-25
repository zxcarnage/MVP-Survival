using Cysharp.Threading.Tasks;
using Db.Camera;
using Extensions.UniRX;
using Game.Camera.Model;
using Game.Services.Input;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Camera.Presenter.Impl
{
    public class CameraPresenter : ICameraPresenter
    {
        private readonly IInputProvider _inputProvider;
        private readonly ICameraParameters _cameraParameters;
        private readonly CameraRotationModel _cameraRotationModel;

        public CameraPresenter(
            IInputProvider inputProvider,
            ICameraParameters cameraParameters,
            CameraRotationModel cameraRotationModel
        )
        {
            _inputProvider = inputProvider;
            _cameraParameters = cameraParameters;
            _cameraRotationModel = cameraRotationModel;
        }

        public void Initialize()
        {
            _inputProvider.InputSystem.Player.Look.ToObservable().Subscribe(ReadInput);
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void ReadInput(InputAction.CallbackContext input)
        {
            var inputDelta = input.ReadValue<Vector2>();
            var frameSensitivity = _cameraParameters.Sensitivity * Time.deltaTime;
            var lookDelta = new Vector3(inputDelta.x, -inputDelta.y, 0f) * frameSensitivity;
            _cameraRotationModel.TargetRotation += lookDelta;
            _cameraRotationModel.TargetRotation.y = Mathf.Clamp(_cameraRotationModel.TargetRotation.y, _cameraParameters.MinMaxY.x, _cameraParameters.MinMaxY.y);
        }
    }
}