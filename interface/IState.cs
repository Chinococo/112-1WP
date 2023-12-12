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
        /// <param name="x">The X-coordinate of the mouse pointer.</param>
        /// <param name="y">The Y-coordinate of the mouse pointer.</param>
        void MouseDown(double x, double y);

        /// <summary>
        /// Method called when the mouse is moved.
        /// </summary>
        /// <param name="x">The X-coordinate of the mouse pointer.</param>
        /// <param name="y">The Y-coordinate of the mouse pointer.</param>
        void MouseMove(double x, double y);

        /// <summary>
        /// Method called when the mouse button is released.
        /// </summary>
        /// <param name="x">The X-coordinate of the mouse pointer.</param>
        /// <param name="y">The Y-coordinate of the mouse pointer.</param>
        void ReleasedPointer(double x, double y);
    }
}