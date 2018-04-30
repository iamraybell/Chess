namespace Chess
{
    public interface IOwner
    {
        ColorType Color { get; }
        string Name { get; }
    }
}