using Game.Camera.Model;
using Game.Camera.Presenter.Impl;
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
            
            //TODO:MODELS
            Container.Bind<CameraRotationModel>().AsSingle();
            
            Container.Bind<InputSystem>().AsSingle();
        }
    }
}