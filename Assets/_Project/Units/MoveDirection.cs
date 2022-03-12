namespace Kamikaze.Units
{
    /// <summary>
    /// Enum telling where a unit should move
    /// </summary>
    public enum MoveDirection
    {
        /// <summary>
        /// Moves the unit from left to right.
        /// </summary>
        Right,

        /// <summary>
        /// Moves the unit from right to left.
        /// </summary>
        Left,

        /// <summary>
        /// The unit wont move.
        /// </summary>
        Idle,
    }
}