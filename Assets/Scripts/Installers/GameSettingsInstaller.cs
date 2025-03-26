using Db.Camera;
using Db.Camera.Impl;
using Db.Collectable;
using Db.Collectable.Impl;
using Db.Player;
using Db.Player.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CameraParameters _cameraParameters;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private CollectableParameters _collectableParameters;
        
        public override void InstallBindings()
        {
            Container.Bind<ICameraParameters>().FromInstance(_cameraParameters).AsSingle();
            Container.Bind<IPlayerParameters>().FromInstance(_playerParameters).AsSingle();
            Container.Bind<ICollectableParameters>().FromInstance(_collectableParameters).AsSingle();
        }
    }
}