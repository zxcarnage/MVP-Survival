using UniRx;

namespace Game.Player.Presenter.Jump.Model
{
    public class GroundedModule
    {
        public ReactiveProperty<bool> IsGrounded { get; } = new ReactiveProperty<bool>(true);
    }
}