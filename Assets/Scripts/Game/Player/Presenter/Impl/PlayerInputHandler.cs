using Extensions.UniRX;
using Game.Player.Models;
using Game.Services.Input;
using UniRx;

namespace Game.Player.Presenter.Impl
{
    public class PlayerInputHandler
    {
        private readonly IInputProvider _inputProvider;
        private readonly ToolsModel _toolsModel;

        private readonly CompositeDisposable _disposable = new();

        public PlayerInputHandler(
            IInputProvider inputProvider,
            ToolsModel toolsModel
        )
        {
            _inputProvider = inputProvider;
            _toolsModel = toolsModel;
        }

        public void Subscribe()
        {
            _inputProvider.InputSystem.Player.ChangeTool.ToObservable().Subscribe(_ => _toolsModel.TryChangeActiveTool()).AddTo(_disposable);
        }

        public void Unsubscribe()
        {
            _disposable?.Dispose();
        }
    }
}