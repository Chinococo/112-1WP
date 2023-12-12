using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.PresentationModel
{
    public class PresentationModel
    {
        private Model _model;
        private Bitmap _bitmap;
        private const string IMAGE = "image.png";

        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // Draw事件
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
            Bitmap myBitmap = new Bitmap((int)graphics.VisibleClipBounds.Width, (int)graphics.VisibleClipBounds.Height);
            myBitmap.Save(IMAGE, System.Drawing.Imaging.ImageFormat.Png);
            _bitmap = myBitmap;
        }

        // 拿bitmap
        public Bitmap GetBitmap()
        {
            return _bitmap;
        }
    }
}