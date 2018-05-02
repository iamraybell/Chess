namespace Chess
{
    public interface IPlayer
    {
        PlayerKind PlayerKind { get; }
        string Name { get; }

        /// <summary>
        /// Ask player to make a move. Returns true if the move was made, otherwise returns false. 
        /// </summary>
        /// <remarks>
        /// If the method returns false, the board will "retry" and call the same method again.
        /// </remarks>
        bool MakeAMove(Board board);
    }
}