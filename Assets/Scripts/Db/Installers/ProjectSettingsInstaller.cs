using Core.ScenesBase;
using Core.ScenesBase.Impl;
using UnityEngine;
using Zenject;

namespace Db.Installers
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ProjectSettingsInstaller), fileName = nameof(ProjectSettingsInstaller))]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScenesBase _scenesBase;

        public override void InstallBindings()
        {
            Container.Bind<IScenesBase>().FromInstance(_scenesBase).AsSingle();
        }
    }
}