using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.BanHang.TRA_HANG;
using QL_Nha_thuoc.BaoCao;
using QL_Nha_thuoc.DangNhap;
using QL_Nha_thuoc.DoiTac;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.HangHoa.ThietLapGia;
using QL_Nha_thuoc.NhanVien;
using QuestPDF.Infrastructure;

namespace QL_Nha_thuoc
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin  ());
        }
    }
}