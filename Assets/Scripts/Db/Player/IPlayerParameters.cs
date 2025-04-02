namespace Db.Player
{
    public interface IPlayerParameters
    {
        float Speed { get; }
        float JumpForce { get; }

        float NeedDecreaseDelay { get; }
    }
}