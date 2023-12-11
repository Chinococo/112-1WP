namespace powerpoint.Object
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
        public void MouseDown(double x, double y)
        {
            this._model.PressPointerDrawing(x, y);
        }

        // Handles the mouse move event by triggering pointer movement in the associated model.
        public void MouseMove(double x, double y)
        {
            this._model.MovedPointerDrawing(x, y);
        }

        // Handles the released pointer event by triggering pointer release in the associated model.
        public void ReleasedPointer(double x, double y)
        {
            this._model.ReleasedPointerDrawing(x, y);
        }
    }
}
