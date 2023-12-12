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
        /// <param name="x">The x-coordinate of the mouse position.</param>
        /// <param name="y">The y-coordinate of the mouse position.</param>
        public void MouseDown(double x, double y)
        {
            this._model.PressPointerPoint(x, y);
        }

        /// <summary>
        /// Handles the mouse move event when the user moves the mouse.
        /// </summary>
        /// <param name="x">The x-coordinate of the mouse position.</param>
        /// <param name="y">The y-coordinate of the mouse position.</param>
        public void MouseMove(double x, double y)
        {
            this._model.MovedPointerPoint(x, y);
        }

        /// <summary>
        /// Handles the released pointer event when the user releases the mouse button.
        /// </summary>
        /// <param name="x">The x-coordinate of the mouse position.</param>
        /// <param name="y">The y-coordinate of the mouse position.</param>
        public void ReleasedPointer(double x, double y)
        {
            this._model.ReleasedPointerPoint(x, y);
        }
    }
}