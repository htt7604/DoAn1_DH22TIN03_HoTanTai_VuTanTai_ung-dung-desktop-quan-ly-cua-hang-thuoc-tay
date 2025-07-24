using QL_Nha_thuoc.model;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.Linq;

public class PhieuKiemKhoDocument : IDocument
{
    private readonly ClassPhieuKiemKho phieu;
    private readonly List<ClassChiTietPhieuKiemKho> chiTietList;

    public PhieuKiemKhoDocument(ClassPhieuKiemKho phieu, List<ClassChiTietPhieuKiemKho> chiTietList)
    {
        this.phieu = phieu;
        this.chiTietList = chiTietList;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(30);
            page.DefaultTextStyle(x => x.FontSize(12));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().AlignCenter().Text(txt =>
            {
                txt.Span("https://vitai.kiotviet.vn/admin/#/StockTakes").FontSize(10);
                txt.Span("  |  Trang ").FontSize(10);
                txt.CurrentPageNumber().FontSize(10);
                txt.Span(" / ");
                txt.TotalPages().FontSize(10);
            });
        });
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(col =>
        {
            col.Item().AlignCenter().Text("Phiếu kiểm kho").Bold().FontSize(16);
            col.Item().Text(txt =>
            {
                txt.Span("Mã phiếu: ").Bold();
                txt.Span(phieu.MaPhieuKiemKho).Bold();
            });

            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text($"Chi nhánh kiểm: {""}");
                    c.Item().Text($"Người tạo: {phieu?.TenNhanVien ?? ""}");
                    c.Item().Text($"Người cân bằng: {phieu?.TenNhanVien ?? ""}");
                });

                row.RelativeItem().Column(c =>
                {
                    c.Item().Text($"Trạng thái: {phieu?.TrangThaiPhieuKiem ?? ""}");
                    c.Item().Text($"Ngày tạo: {phieu?.NgayKiemKho?.ToString("dd/MM/yyyy HH:mm") ?? ""}");
                    c.Item().Text($"Ngày cân bằng: {(phieu?.NgayKiemKho?.ToString("dd/MM/yyyy") ?? "")}");
                });
            });
        });
    }

    void ComposeContent(IContainer container)
    {
        container.Column(col =>
        {
            // Bảng chi tiết
            col.Item().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30); // STT
                    columns.RelativeColumn(1);  // Mã hàng
                    columns.RelativeColumn(2);  // Tên hàng
                    columns.RelativeColumn(1);  // Tồn kho
                    columns.RelativeColumn(1);  // Kiểm thực tế
                    columns.RelativeColumn(1);  // SL lệch
                    columns.RelativeColumn(1);  // Giá trị lệch
                });

                table.Header(header =>
                {
                    header.Cell().Text("STT").Bold();
                    header.Cell().Text("Mã hàng").Bold();
                    header.Cell().Text("Tên hàng").Bold();
                    header.Cell().Text("Tồn kho").Bold();
                    header.Cell().Text("Kiểm thực tế").Bold();
                    header.Cell().Text("SL lệch").Bold();
                    header.Cell().Text("Giá trị lệch").Bold();
                });

                int stt = 1;
                foreach (var item in chiTietList)
                {
                    table.Cell().Text(stt++.ToString());
                    table.Cell().Text(item.MaHangHoa ?? "");
                    table.Cell().Text(item.TenHangHoa ?? "");
                    table.Cell().Text(item.SoLuongHeThong.ToString());
                    table.Cell().Text(item.SoLuongThucTe.ToString());
                    table.Cell().Text(item.ChenhLech.ToString());
                    table.Cell().Text("0"); // Thay bằng item.GiaTriLech nếu có
                }
            });

            col.Item().Text("Ghi chú:").Italic();

            // Tổng kết
            int tongThucTe = chiTietList.Sum(x => x.SoLuongThucTe);
            int tongLechTang = chiTietList.Where(x => x.ChenhLech > 0).Sum(x => x.ChenhLech);
            int tongLechGiam = chiTietList.Where(x => x.ChenhLech < 0).Sum(x => x.ChenhLech);
            int tongChenhLech = chiTietList.Sum(x => x.ChenhLech);

            col.Item().PaddingTop(15).Column(t =>
            {
                t.Item().Text($"Tổng thực tế ({tongThucTe}): 0");
                t.Item().Text($"Tổng lệch tăng ({tongLechTang}): 0");
                t.Item().Text($"Tổng lệch giảm ({tongLechGiam}): 0");
                t.Item().Text($"Tổng chênh lệch ({tongChenhLech}): 0");
            });
        });
    }
}
