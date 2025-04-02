using Core.Utils;
using Game.Services.SceneLoading;
using Ui.MainMenu;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui
{
    public class LoadSceneButton : AButton
    {
        [SerializeField] private EGameSceneType _sceneType;
        
        private ISceneLoadingManager _sceneLoadingManager;

        [Inject]
        private void Construct(ISceneLoadingManager sceneLoadingManager)
        {
            _sceneLoadingManager = sceneLoadingManager;
        }
        
        protected override void OnAction(Unit unit)
        {
            _sceneLoadingManager.LoadScene(_sceneType);
        }
    }
}