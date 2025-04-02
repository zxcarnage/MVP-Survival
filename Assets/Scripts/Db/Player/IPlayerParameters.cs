namespace Db.Player
{
    public interface IPlayerParameters
    {
        int Health { get; }
        int Water { get; }
        int Hunger { get; }
        float Luck { get; }
        float Speed { get; }
        float JumpForce { get; }

        float NeedDecreaseDelay { get; }
    }
}