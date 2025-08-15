using QL_Nha_thuoc.model;
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

namespace QL_Nha_thuoc.ThongKeTongquan
{
    public partial class FormTongQuan : Form
    {
        public FormTongQuan()
        {
            InitializeComponent();
        }

        private void FormTongQuan_Load(object sender, EventArgs e)
        {
            comboBoxThoiGianLocDoanhThu.Items.Clear();
            comboBoxThoiGianLocDoanhThu.Items.Add("hôm nay");
            comboBoxThoiGianLocDoanhThu.Items.Add("tuần này");
            comboBoxThoiGianLocDoanhThu.SelectedIndex = 0;

            // Thiết lập khoảng thời gian mặc định
            tungay = DateTime.Today.AddDays(-1);
            denngay = DateTime.Today.AddDays(+1);

            decimal tongDoanhThu = ClassPhieuThuChi.LayTongDoanhThu(tungay, denngay);
            labelSoTienDoanhThu.Text = tongDoanhThu.ToString("N0");

            int soHoaDon = ClassPhieuThuChi.DemSoPhieuThu(tungay, denngay);
            labelSoHoaDon.Text = soHoaDon + " hóa đơn";
            VeBieuDoTheoNgayVaSanPham(tungay, denngay);
        }


        private void VeBieuDoTopSanPhamBanChayTheoTongTien(DateTime tuNgay, DateTime denNgay)
        {
            // Lấy top sản phẩm
            var topSanPham = ClassHoaDon
                .LayTop10HangHoaTheoTongGiaTri(tuNgay, denNgay)
                .ToList();

            // Debug
            foreach (var sp in topSanPham)
            {
                Console.WriteLine($"{sp.TenHangHoa} - Giá trị: {sp.TongGiaTri:N0} ₫");
            }

            chartTop10HangHoa.Series.Clear();
            chartTop10HangHoa.ChartAreas.Clear();
            chartTop10HangHoa.Legends.Clear();

            // Tạo ChartArea
            var chartArea = new ChartArea("ChartArea1");
            chartArea.BackColor = Color.White;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.Title = "Sản phẩm";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisX.LabelStyle.Angle = -20; // nghiêng chữ nếu tên dài

            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Title = "Doanh thu (₫)";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 11, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.LabelStyle.Format = "N0";
            chartArea.AxisY.Minimum = 0;

            chartTop10HangHoa.ChartAreas.Add(chartArea);

            // Thêm Legend để hiển thị tên sản phẩm
            var legend = new Legend();
            legend.Font = new Font("Segoe UI", 9);
            chartTop10HangHoa.Legends.Add(legend);

            // Random màu
            Random rnd = new Random();

            // Mỗi sản phẩm là 1 series
            foreach (var sp in topSanPham)
            {
                var series = new Series(sp.TenHangHoa);
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";
                series["PointWidth"] = "0.3"; // thu nhỏ cột để tạo khoảng trống
                series.IsXValueIndexed = true;
                series.Points.AddY(sp.TongGiaTri);
                series.Points[0].Color = Color.FromArgb(rnd.Next(50, 200), rnd.Next(50, 200), rnd.Next(50, 200));
                series.Points[0].Label = $"{sp.TongGiaTri:N0} ₫";

                chartTop10HangHoa.Series.Add(series);
            }
        }








        //bien luu thoi gian loc doanh thu
        private DateTime tungay = DateTime.Today.AddDays(-1);
        private DateTime denngay = DateTime.Today.AddDays(+1);

        private void VeBieuDoTheoNgayVaSanPham(DateTime tuNgay, DateTime denNgay)
        {
            // Lấy dữ liệu (Ngày, Tên sản phẩm, Doanh thu)
            var data = ClassHoaDon.LayDoanhThuTheoNgayVaSanPham(tuNgay, denNgay)
                                  .OrderBy(x => x.Ngay)
                                  .ToList();

            // Tạo dải ngày đầy đủ (kể cả ngày trống dữ liệu)
            var days = Enumerable.Range(0, (denNgay.Date - tuNgay.Date).Days + 1)
                                 .Select(i => tuNgay.Date.AddDays(i))
                                 .ToList();

            // Danh sách sản phẩm
            var products = data.Select(d => d.TenSanPham).Distinct().ToList();

            chartTop10HangHoa.Series.Clear();
            chartTop10HangHoa.ChartAreas.Clear();
            chartTop10HangHoa.Legends.Clear();

            // ChartArea
            var area = new ChartArea("MainArea");
            area.BackColor = Color.White;

            // Trục X theo ngày
            area.AxisX.Title = "Ngày";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.IsMarginVisible = true;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisX.LabelStyle.Format = "dd/MM";

            // Trục Y là doanh thu
            area.AxisY.Title = "Doanh thu (₫)";
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.Minimum = 0;

            chartTop10HangHoa.ChartAreas.Add(area);

            // Legend
            var legend = new Legend
            {
                Docking = Docking.Top,
                Font = new Font("Segoe UI", 9)
            };
            chartTop10HangHoa.Legends.Add(legend);

            // Nếu không có sản phẩm nào -> tạo series trống để vẫn hiện trục ngày
            if (products.Count == 0)
            {
                var s = new Series("Không có dữ liệu")
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.Date,
                    IsXValueIndexed = true
                };
                s["PixelPointWidth"] = "30"; // độ rộng cột cố định theo pixel
                s["PointWidth"] = "1.7";     // dùng kèm để tạo khoảng hở đẹp
                foreach (var day in days)
                {
                    s.Points.AddXY(day, 0);
                }
                chartTop10HangHoa.Series.Add(s);
                return;
            }

            // Bảng màu mặc định sáng, mỗi series một màu
            chartTop10HangHoa.Palette = ChartColorPalette.Bright;

            // Mỗi sản phẩm = 1 series
            foreach (var sp in products)
            {
                var series = new Series(sp)
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.Date,
                    IsXValueIndexed = true,       // đảm bảo các cột canh thẳng theo từng ngày
                                                  // IsValueShownAsLabel = true, // dùng nhãn theo từng điểm để tránh hiện số 0
                    LabelFormat = "N0"
                };

                // Tạo khoảng cách cột đẹp hơn
                series["PixelPointWidth"] = "50"; // nhỏ lại để có khoảng hở giữa nhóm ngày
                series["PointWidth"] = "7.6";

                // Thêm điểm theo từng ngày; ngày không có dữ liệu -> 0
                foreach (var day in days)
                {
                    var value = data
                        .Where(d => d.TenSanPham == sp && d.Ngay.Date == day.Date)
                        .Sum(d => d.DoanhThu);

                    int pointIndex = series.Points.AddXY(day, (double)value);

                    // Chỉ hiện nhãn khi > 0 để đỡ rối
                    if (value > 0)
                    {
                        series.Points[pointIndex].IsValueShownAsLabel = true;
                        series.Points[pointIndex].Label = string.Format("{0:N0}", value);
                    }
                }

                chartTop10HangHoa.Series.Add(series);
            }
        }




        private void comboBoxThoiGianLocDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxThoiGianLocDoanhThu.SelectedIndex == 0) // Hôm nay
            {
                tungay = DateTime.Today.AddDays(-1);
                denngay = DateTime.Today.AddDays(+1);
                VeBieuDoTheoNgayVaSanPham(tungay, denngay);
            }
            else if (comboBoxThoiGianLocDoanhThu.SelectedIndex == 1) // Tuần này
            {
                tungay = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); // Thứ 2
                denngay = tungay.AddDays(6); // Chủ nhật
                VeBieuDoTheoNgayVaSanPham(tungay, denngay);
            }
            //if (comboBoxThoiGianLocDoanhThu.SelectedIndex == 0) // Hôm nay
            //{
            //    tungay = DateTime.Today; // 00:00:00
            //    denngay = DateTime.Today.AddDays(1).AddTicks(-1); // 23:59:59
            //    VeBieuDoTopSanPhamBanChayTheoTongTien(tungay, denngay);
            //}
            //else if (comboBoxThoiGianLocDoanhThu.SelectedIndex == 1) // Tuần này
            //{
            //    tungay = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
            //    denngay = tungay.AddDays(7).AddTicks(-1);
            //    VeBieuDoTheoNgayVaSanPham(tungay, denngay);
            //}

        }

    }
}
