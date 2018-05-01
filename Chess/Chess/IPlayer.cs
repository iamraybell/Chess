namespace Chess
{
    public interface IPlayer
    {
        PlayerKind Color { get; }
        string Name { get; }
    }
}