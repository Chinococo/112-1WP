using System.Collections.Generic;

    public class Shapes
    {
        protected string _shapeName;
        public double x1;
        public double y1;
        public double x2;
        public double y2;
        public Shapes(string shapename)
        {
            this._shapeName = shapename;
        }
    public Shapes(string shapename, double x1, double y1, double x2, double y2)
    {
        this._shapeName = shapename;
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
    }

}


