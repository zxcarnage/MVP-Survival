using Game.Camera.Model;
using Game.Camera.Presenter.Impl;
using Game.Collectable;
using Game.Player;
using Game.Player.Presenter.Impl;
using Game.Player.Presenter.Jump.Impl;
using Game.Player.Presenter.Jump.Model;
using Game.Services.Input.Impl;
using Game.Services.Skill;
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
            Container.BindInterfacesAndSelfTo<SkillService>().AsSingle();
            
            //TODO:PRESENTERS
            Container.BindInterfacesAndSelfTo<CameraPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovementPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerJumpPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollectablePresenter>().AsSingle();
            
            //TODO:MODELS
            Container.Bind<CameraRotationModel>().AsSingle();
            Container.Bind<MovementDirectionModel>().AsSingle();
            Container.Bind<JumpModel>().AsSingle();
            Container.Bind<GroundedModule>().AsSingle();
            Container.Bind<InventoryModel>().AsSingle();
            Container.Bind<ExperienceModel>().AsSingle();
            Container.Bind<SkillPointsModel>().AsSingle();
            
            Container.Bind<InputSystem>().AsSingle();
        }
    }
}