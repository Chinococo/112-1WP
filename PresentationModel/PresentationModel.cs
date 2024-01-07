using Dialog;
using PowerPoint.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PowerPoint.PresentationModel
{
    public class PresentationModel
    {
        private Model _model;
        private Bitmap _bitmap;
        private Factory _factory = new Factory();
        private const string IMAGE = "image.png";
        private IState _state; // 表示當前狀態的接口
        private BindingList<Shape> _shapeList;
        private ControlManager _controlManager;
        private const string LINE = "線";
        private const string RECTANGLE = "矩形";
        private const string ELLIPSE = "橢圓";
        private const string NAME_LINE = "Line";
        private const string NAME_RECTANGLE = "Rectangle";
        private const string NAME_ELLIPSE = "Ellipse";
        private string _shapeState = "";

        public PresentationModel(Model model, BindingList<Shape> shapeList, ControlManager controlManager)
        {
            this._model = model;
            this._shapeList = shapeList;
            this._controlManager = controlManager;
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

        // 滑鼠移動事件處理（由 IState 接口實現）
        public void MovedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.MouseMove(pressX, pressY);
        }

        // 滑鼠左鍵釋放事件處理（由 IState 接口實現）
        public void ReleasedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.ReleasedPointer(pressX, pressY);
        }

        // 滑鼠按下事件處理（由 IState 接口實現）
        public void PressedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.MouseDown(pressX, pressY);
        }

        // 切換繪製狀態
        public void ChangeState(bool drawingState)
        {
            if (drawingState)
                _state = new DrawingState(_model);
            else
                _state = new PointState(_model);
        }

        // 按鈕刪除 Click 事件處理
        public void DeleteButtonClick()
        {
            int selectIndex = _model.GetSelectIndex();
            if (selectIndex >= 0 && selectIndex < _shapeList.Count)
            {
                _controlManager.DeleteCommand(_model, _shapeList[selectIndex].Clone(), selectIndex);
                _shapeList.RemoveAt(selectIndex);
            }
            // 通知模型發生變化
            _model.NotifyModelChanged();
        }

        // 新增 DataGrid 資料
        public void AddNewLine(string state, Point leftTop, Point rightBottom)
        {
            if (state == LINE)
                _shapeList.Add(_factory.CreateShape(NAME_LINE, leftTop, rightBottom));
            else if (state == RECTANGLE)
                _shapeList.Add(_factory.CreateShape(NAME_RECTANGLE, leftTop, rightBottom));
            else if (state == ELLIPSE)
                _shapeList.Add(_factory.CreateShape(NAME_ELLIPSE, leftTop, rightBottom));
            _shapeState = state;
            _controlManager.AddCommand(_model, _shapeList[_shapeList.Count - 1].Clone());
            _model.NotifyModelChanged();
        }

        //設定ShapeList
        public void SetShapeList(BindingList<Shape> shapeList)
        {
            this._shapeList = shapeList;
        }

        //儲存CSV
        public void SaveByFileToCSV(List<BindingList<Shape>> shapeList, List<Size> drawPanelSizeList)
        {
            const string FILE_PATH = "SaveData.csv";
            if (File.Exists(FILE_PATH))
            {
                File.Delete(FILE_PATH);
            }
            // Sample data to write to the CSV file
            for (int i = 0; i < shapeList.Count; i++)
            {
                for (int k = 0; k < shapeList[i].Count; k++)
                {
                    string[] data = { i.ToString(), drawPanelSizeList[0].Width.ToString(), drawPanelSizeList[0].Height.ToString() };
                    string[] temp = shapeList[i][k].GetInfoCsv().Split(',');
                    data = data.Concat(temp).ToArray(); ;
                    WriteToCsv(FILE_PATH, null, data);
                }
            }
        }

        //寫入CSV
        public static void WriteToCsv(string filePath, string[] headers, string[] data)
        {
            // Check if the file already exists
            bool fileExists = File.Exists(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Write headers if the file is newly created
                if (!fileExists && headers != null)
                {
                    writer.WriteLine(string.Join(",", headers));
                }
                if (data != null)
                {
                    // Write data
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }

        //讀取CSV
        public List<CsvData> ReadCsvFile(string filePath)
        {
            try
            {
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(filePath);

                // Skip header if present
                lines = lines.ToArray();

                // Process lines using LINQ
                List<CsvData> dataList = lines
                    .Select(line => line.Split(','))
                    .Select(fields => new CsvData
                    {
                        PanelIndex = int.Parse(fields[0]),
                        DrawWidth = int.Parse(fields[1]),
                        DrawHeight = int.Parse(fields[2]),
                        ShapeType = fields[3],
                        X1 = int.Parse(fields[4]),
                        Y1 = int.Parse(fields[5]),
                        X2 = int.Parse(fields[6]),
                        Y2 = int.Parse(fields[7])
                    })
                    .ToList();

                return dataList;
            }
            catch (Exception ex)
            {
                return new List<CsvData>();
            }
        }
    }
}