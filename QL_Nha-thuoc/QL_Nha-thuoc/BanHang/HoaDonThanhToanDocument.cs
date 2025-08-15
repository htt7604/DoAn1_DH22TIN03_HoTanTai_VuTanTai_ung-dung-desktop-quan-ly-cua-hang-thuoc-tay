using QL_Nha_thuoc.model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using QuestPDF.Helpers;



public class HoaDonThanhToanDocument : IDocument
{
    private readonly ClassHoaDon hoaDon;
    private readonly List<ClassChiTietHoaDon> chiTietList;
    private readonly string qrCodeUrl;

    public HoaDonThanhToanDocument(ClassHoaDon hoaDon, List<ClassChiTietHoaDon> chiTietList, string qrCodeUrl)
    {
        this.hoaDon = hoaDon;
        this.chiTietList = chiTietList;
        this.qrCodeUrl = qrCodeUrl;
    }


    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(30);
            page.DefaultTextStyle(x => x.FontSize(11));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    void ComposeHeader(IContainer container)
    {
        ClassTaiKhoan taikhoan = Session.TaiKhoanDangNhap;
        container.Column(col =>
        {
            // Logo + Tên cửa hàng
            col.Item().Row(row =>
            {
                row.RelativeItem().Height(50).AlignCenter().AlignMiddle().Text("🏥").FontSize(30); // Có thể thay bằng hình ảnh logo
                row.RelativeItem(3).Column(c =>
                {
                    c.Item().Text("Nhà thuốc").Bold().FontSize(16).FontColor(Colors.Blue.Medium);
                    c.Item().Text(taikhoan.TenTaiKhoan);
                    c.Item().Text("Địa chỉ: Cần Thơ");
                    c.Item().Text("Điện thoại: 0866850269");
                });
            });

            col.Item().PaddingVertical(10).AlignCenter().Text("HÓA ĐƠN BÁN HÀNG").Bold().FontSize(14);
            col.Item().AlignCenter().Text($"Số HĐ: {hoaDon?.MaHoaDon ?? "HD000000"}");
            col.Item().AlignCenter().Text($"Ngày {hoaDon?.NgayLapHD?.ToString("dd")} tháng {hoaDon?.NgayLapHD?.ToString("MM")} năm {hoaDon?.NgayLapHD?.ToString("yyyy")}");
        });
    }

    void ComposeContent(IContainer container)
    {
        ClassKhachHang khachhang= ClassKhachHang.LayThongTinKhachHangTheoMa(hoaDon.MaKH);
        container.Column(col =>
        {
            // Thông tin khách hàng
            col.Item().PaddingVertical(10).Column(info =>
            {
                info.Item().Text($"Khách hàng: {khachhang?.TenKH ?? "Khách lẻ"}");
                info.Item().Text($"SĐT: {khachhang?.SDT ?? "-"}");
                info.Item().Text($"Địa chỉ: {khachhang?.DiaChiKH ?? "-"}");
                info.Item().Text($"Số CCCD: {khachhang?.SoCCCD_CMND ?? "-"}");
            });

            // Bảng sản phẩm
            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3); // Tên hàng
                    columns.RelativeColumn(1); // Đơn giá
                    columns.RelativeColumn(1); // SL
                    columns.RelativeColumn(1); // Thành tiền
                });

                table.Header(header =>
                {
                    header.Cell().Text("Tên hàng").Bold();
                    header.Cell().AlignRight().Text("Đơn giá").Bold();
                    header.Cell().AlignCenter().Text("SL").Bold();
                    header.Cell().AlignRight().Text("Thành tiền").Bold();
                });

                foreach (var item in chiTietList)
                {
                    table.Cell().Text(item.TenHangHoa ?? "");
                    table.Cell().AlignRight().Text($"{item.DonGiaBan:#,##0}");
                    table.Cell().AlignCenter().Text($"{item.SoLuong}");
                    table.Cell().AlignRight().Text($"{item.ThanhTien:#,##0}");
                }
            });

            // Tổng kết
            col.Item().PaddingTop(10).AlignRight().Column(c =>
            {
                var tongTien = chiTietList.Sum(x => x.ThanhTien);
                var giamGia = hoaDon?.GiamGia ?? 0;
                var tongThanhToan = tongTien - giamGia;

                c.Item().Text($"Tổng tiền hàng: {tongTien:#,##0}");
                c.Item().Text($"Chiết khấu: {giamGia:#,##0}");
                c.Item().Text($"Tổng thanh toán: {tongThanhToan:#,##0}").Bold();
            });

            col.Item().AlignCenter().PaddingTop(10).Text("Quét mã thanh toán").Italic();
            // Hiển thị QR thanh toán nếu có
            if (!string.IsNullOrEmpty(qrCodeUrl))
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] data = client.DownloadData(qrCodeUrl);
                        col.Item().AlignCenter().PaddingTop(10).Container().Width(250).Height(250).Image(data, ImageScaling.FitArea);
                    }
                }
                catch
                {
                    col.Item().AlignCenter().PaddingTop(10).Text("Không thể tải mã QR").Italic();
                }
            }


            col.Item().AlignCenter().PaddingTop(5).Text("Cảm ơn và hẹn gặp lại!").Italic();
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.AlignLeft().Text(txt =>
        {
            txt.Span(qrCodeUrl).FontSize(10);
            txt.Span("     |     Trang ").FontSize(10);
            txt.CurrentPageNumber().FontSize(10);
            txt.Span(" / ");
            txt.TotalPages().FontSize(10);
        });
    }
}
