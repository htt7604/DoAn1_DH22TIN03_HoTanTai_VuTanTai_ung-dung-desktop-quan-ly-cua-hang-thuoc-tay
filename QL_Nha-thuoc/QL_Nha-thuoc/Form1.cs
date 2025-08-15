using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QL_Nha_thuoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Giả sử bạn có Chart tên chartTop10HangHoa trên Form
            VeBieuDoTopSanPhamBanChayTheoTongTien(chart1);

        }
        public void VeBieuDoTopSanPhamBanChayTheoTongTien(Chart chartTop10HangHoa)
        {
            var topSanPham = new List<(string TenHangHoa, double TongGiaTri)>
    {
        ("Kem dưỡng da tay y tế", 600000),
        ("Sữa rửa mặt dịu nhẹ", 140000),
        ("Son dưỡng môi", 350000)
    };

            chartTop10HangHoa.Series.Clear();
            chartTop10HangHoa.ChartAreas.Clear();
            chartTop10HangHoa.Legends.Clear();

            // ChartArea
            var chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -20;
            chartArea.AxisX.MajorGrid.Enabled = false;

            chartArea.AxisY.Title = "Doanh thu (₫)";
            chartArea.AxisY.LabelStyle.Format = "N0";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Minimum = 0;

            chartTop10HangHoa.ChartAreas.Add(chartArea);

            // Legend
            var legend = new Legend();
            chartTop10HangHoa.Legends.Add(legend);

            int index = 0;
            foreach (var sp in topSanPham)
            {
                var series = new Series(sp.TenHangHoa);
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                // Nhỏ lại để tạo khoảng trống
                series["PointWidth"] = "0.4";
                series.IsXValueIndexed = true;

                series.Color = GetRandomColor();

                // Dùng X là index thay vì tên để có spacing
                series.Points.AddXY(index, sp.TongGiaTri);
                chartTop10HangHoa.Series.Add(series);

                index += 2; // tăng 2 để tạo khoảng trống
            }
            chartTop10HangHoa.ChartAreas[0].AxisX.LabelStyle.Enabled = false; // tắt nhãn số


        }

        // Hàm random màu
        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(50, 256), rnd.Next(50, 256), rnd.Next(50, 256));
        }




    }
}
