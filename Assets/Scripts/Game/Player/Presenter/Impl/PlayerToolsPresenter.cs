using Game.Collectable;
using Game.Player.Models;
using UniRx;

namespace Game.Player.Presenter.Impl
{
    public class PlayerToolsPresenter : IPlayerToolsPresenter
    {
        private readonly ToolsModel _toolsModel;

        private readonly CompositeDisposable _disposable = new();
        private PlayerToolsView _playerToolsView;

        public PlayerToolsPresenter(
            ToolsModel toolsModel
        )
        {
            _toolsModel = toolsModel;
        }
        
        public void Enable(PlayerToolsView playerToolsView)
        {
            _playerToolsView = playerToolsView;
            _toolsModel.ActiveTool.Pairwise().Subscribe(pair => ChangeToolView(pair.Previous, pair.Current));
        }

        private void ChangeToolView(EToolType previous, EToolType current)
        {
            _playerToolsView.UpdateView(previous, current);
        }

        public void Disable()
        {
            _disposable?.Dispose();
        }
    }
}