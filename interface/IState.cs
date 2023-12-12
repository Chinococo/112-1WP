namespace PowerPoint
{
    /// <summary>
    /// Interface defining the contract for a state in the context of user interactions.
    /// </summary>
    internal interface IState
    {
        /// <summary>
        /// Method called when the mouse button is pressed.
        /// </summary>
        /// <param name="pressX">The X-coordinate of the mouse pointer.</param>
        /// <param name="pressY">The Y-coordinate of the mouse pointer.</param>
        void MouseDown(double pressX, double pressY);

        /// <summary>
        /// Method called when the mouse is moved.
        /// </summary>
        /// <param name="pressX">The X-coordinate of the mouse pointer.</param>
        /// <param name="pressY">The Y-coordinate of the mouse pointer.</param>
        void MouseMove(double pressX, double pressY);

        /// <summary>
        /// Method called when the mouse button is released.
        /// </summary>
        /// <param name="pressX">The X-coordinate of the mouse pointer.</param>
        /// <param name="pressY">The Y-coordinate of the mouse pointer.</param>
        void ReleasedPointer(double pressX, double pressY);
    }
}