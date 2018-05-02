namespace Chess
{
    public class PossibleMove
    {
        public Position TargetPosition { get; }
        
        public Position AttackedPosition { get; }

        public bool IsAttack => AttackedPosition != null;

        private PossibleMove(Position targetPosition)
        {
            TargetPosition = targetPosition;
        }

        private PossibleMove(Position targetPosition, Position attackedPosition)
        {
            TargetPosition = targetPosition;
            AttackedPosition = attackedPosition;
        }

        public static PossibleMove Move(Position targetPosition) => new PossibleMove(targetPosition);

        public static PossibleMove Attack(Position targetPosition, Position attackingPosition = null)
        {
            // In most cases the attacking position is the same as the target position, that's why attackingPosition argument
            // is optional. In this case we use targetPosition as attackingPosition
            if (attackingPosition == null)
            {
                return new PossibleMove(targetPosition, targetPosition);
            }

            return new PossibleMove(targetPosition, attackingPosition);
        }
    }
}
