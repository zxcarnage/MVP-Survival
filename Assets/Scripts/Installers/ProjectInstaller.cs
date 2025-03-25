using Db.Installers;
using Game.Services.SceneLoading.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;

            Container.BindInterfacesAndSelfTo<SceneLoadingManager>().AsSingle();
        }
    }
}