using UniRx;

namespace Game.Player.Presenter.Jump.Model
{
    public class JumpModel
    {
        public ReactiveProperty<bool> ShouldJump { get; } = new (false);
    }
}