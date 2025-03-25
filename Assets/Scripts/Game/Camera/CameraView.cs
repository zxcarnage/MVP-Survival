using Db.Camera;
using Game.Camera.Model;
using Game.Camera.Presenter;
using UnityEngine;
using Zenject;

namespace Game.Camera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private Transform _lookAtTransform;
        [SerializeField] private Transform _followTransform;
        
        private ICameraPresenter _cameraPresenter;
        private ICameraParameters _cameraParameters;
        private CameraRotationModel _cameraRotationModel;

        [Inject]
        public void Construct(
            ICameraPresenter cameraPresenter,
            ICameraParameters cameraParameters,
            CameraRotationModel cameraRotationModel
        )
        {
            _cameraPresenter = cameraPresenter;
            _cameraParameters = cameraParameters;
            _cameraRotationModel = cameraRotationModel;
        }

        private void Start()
        {
            _cameraPresenter.Initialize();
        }

        private void LateUpdate()
        {
            var targetRotation = _cameraRotationModel.TargetRotation;
            var targetRotationX = Quaternion.Euler(targetRotation.y, 0f, 0f);
            var targetRotationY = Quaternion.Euler(0f, targetRotation.x, 0f);
            _lookAtTransform.localRotation = targetRotationX;
            _followTransform.localRotation = targetRotationY;
        }
    }
}