using Db.CharacterChoose.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CharacterContextInstaller : MonoInstaller
    {
        [SerializeField] private CharacterChooseParameters _characterChooseParameters;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterChooseParameters>().FromInstance(_characterChooseParameters).AsSingle();
        }
    }
}