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

namespace QL_Nha_thuoc.BaoCao
{
    public partial class FormBCBanHang : Form
    {
        public FormBCBanHang()
        {
            InitializeComponent();
            LoadChart();
        }
        private void LoadChart()
        {
            // Lấy danh sách hóa đơn
            List<ClassHoaDon> danhSach = ClassHoaDon.LayDanhSachHoaDon();

            // Gom nhóm theo ngày, tính tổng thành tiền
            var doanhThuTheoNgay = danhSach
                .Where(hd => hd.NgayLapHD.HasValue && hd.ThanhTien.HasValue)
                .GroupBy(hd => hd.NgayLapHD.Value.Date)
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongThanhTien = g.Sum(hd => hd.ThanhTien.Value)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            // Cấu hình chart
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            chartArea.AxisY.Title = "Doanh Thu (VNĐ)";
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            chartDoanhThu.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "DoanhThu",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.DateTime
            };

            foreach (var item in doanhThuTheoNgay)
            {
                series.Points.AddXY(item.Ngay, item.TongThanhTien);
            }

            chartDoanhThu.Series.Add(series);

            chartDoanhThu.Legends.Clear();
            chartDoanhThu.Legends.Add(new Legend("DoanhThuLegend"));
        }

        private void FormBCBanHang_Load(object sender, EventArgs e)
        {
            radioButtonqtnhanvien.Checked = true;
            radioButtonqtthoigian.Checked = false;
            checkBoxLuaChonThoiGian.Checked = false;

            comboBoxkhoanthoigian.Items.Add("Hôm nay");
            comboBoxkhoanthoigian.Items.Add("Hôm qua");
            comboBoxkhoanthoigian.Items.Add("Tuần này");
            comboBoxkhoanthoigian.Items.Add("Tháng này");
            comboBoxkhoanthoigian.SelectedIndex = 0;
        }

        private void checkBoxLuaChonThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLuaChonThoiGian.Checked)
            {
                dateTimePickerTuNgay.Enabled = true;
                dateTimePickerDenNgay.Enabled = true;
            }
            else
            {
                dateTimePickerTuNgay.Enabled = false;
                dateTimePickerDenNgay.Enabled = false;
            }

        }

        private void radioButtonqtthoigian_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonqtnhanvien_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxkhoanthoigian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
