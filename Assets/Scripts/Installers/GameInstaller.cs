using Game.Camera.Model;
using Game.Camera.Presenter.Impl;
using Game.Player;
using Game.Player.Presenter.Impl;
using Game.Services.Input.Impl;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
            
            //TODO:SERVICES
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            
            //TODO:PRESENTERS
            Container.BindInterfacesAndSelfTo<CameraPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovementPresenter>().AsSingle();
            
            //TODO:MODELS
            Container.Bind<CameraRotationModel>().AsSingle();
            Container.Bind<MovementDirectionModel>().AsSingle();
            
            Container.Bind<InputSystem>().AsSingle();
        }
    }
}