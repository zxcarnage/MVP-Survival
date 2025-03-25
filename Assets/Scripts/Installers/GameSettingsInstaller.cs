using Db.Camera;
using Db.Camera.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CameraParameters _cameraParameters;
        
        public override void InstallBindings()
        {
            Container.Bind<ICameraParameters>().FromInstance(_cameraParameters).AsSingle();
        }
    }
}