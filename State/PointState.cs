namespace PowerPoint.Object
{
    /// <summary>
    /// Represents the state of the application when the user is interacting with a point.
    /// </summary>
    internal class PointState : IState
    {
        private Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointState"/> class.
        /// </summary>
        /// <param name="model">The model associated with the state.</param>
        public PointState(Model model)
        {
            this._model = model;
        }

        /// <summary>
        /// Handles the mouse down event when the user presses the mouse button.
        /// </summary>
        /// <param name="pressX">The x-coordinate of the mouse position.</param>
        /// <param name="pressY">The y-coordinate of the mouse position.</param>
        public void MouseDown(double pressX, double pressY)
        {
            this._model.PressPoint(pressX, pressY);
        }

        /// <summary>
        /// Handles the mouse move event when the user moves the mouse.
        /// </summary>
        /// <param name="pressX">The x-coordinate of the mouse position.</param>
        /// <param name="pressY">The y-coordinate of the mouse position.</param>
        public void MouseMove(double pressX, double pressY)
        {
            this._model.MovedPointerPoint(pressX, pressY);
        }

        /// <summary>
        /// Handles the released pointer event when the user releases the mouse button.
        /// </summary>
        /// <param name="pressX">The x-coordinate of the mouse position.</param>
        /// <param name="pressY">The y-coordinate of the mouse position.</param>
        public void ReleasedPointer(double pressX, double pressY)
        {
            this._model.ReleasedPointerPoint(pressX, pressY);
        }
    }
}