namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class DrawingState : IState
    {
        private Model _model;

        // Initializes a new instance of the DrawingState class with the specified model.
        public DrawingState(Model model)
        {
            _model = model;
        }

        // Gets the associated model for this drawing state.
        public Model Model
        {
            get;
        }

        // Handles the mouse down event by triggering pointer press in the associated model.
        public void MouseDown(double pressX, double pressY)
        {
            this._model.PressPointerDrawing(pressX, pressY);
        }

        // Handles the mouse move event by triggering pointer movement in the associated model.
        public void MouseMove(double pressX, double pressY)
        {
            this._model.MovedPointerDrawing(pressX, pressY);
        }

        // Handles the released pointer event by triggering pointer release in the associated model.
        public void ReleasedPointer(double pressX, double pressY)
        {
            this._model.ReleasedPointerDrawing(pressX, pressY);
        }
    }
}