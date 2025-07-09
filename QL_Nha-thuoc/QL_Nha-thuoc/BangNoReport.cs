using QuestPDF.Drawing;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

public class BangNoReport
{
    public class NoItem
    {
        public int STT { get; set; }
        public string MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public decimal SoTienNo { get; set; }
        public string GhiChu { get; set; }
    }

    public static void Generate(string filePath, List<NoItem> danhSachNo)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);

                page.Header()
                    .Text("BÁO CÁO BẢNG NỢ")
                    .FontSize(20)
                    .Bold()
                    .AlignCenter();

                page.Content()
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(40); // STT
                            columns.RelativeColumn(1);  // Mã
                            columns.RelativeColumn(2);  // Tên
                            columns.RelativeColumn(1);  // Số tiền
                            columns.RelativeColumn(2);  // Ghi chú
                        });

                        // Header row
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("STT").Bold();
                            header.Cell().Element(CellStyle).Text("Mã Đối Tượng").Bold();
                            header.Cell().Element(CellStyle).Text("Tên Đối Tượng").Bold();
                            header.Cell().Element(CellStyle).Text("Số Tiền Nợ").Bold();
                            header.Cell().Element(CellStyle).Text("Ghi Chú").Bold();
                        });

                        // Data rows
                        foreach (var item in danhSachNo)
                        {
                            table.Cell().Element(CellStyle).Text(item.STT.ToString());
                            table.Cell().Element(CellStyle).Text(item.MaDoiTuong);
                            table.Cell().Element(CellStyle).Text(item.TenDoiTuong);
                            table.Cell().Element(CellStyle).Text($"{item.SoTienNo:N0} đ");
                            table.Cell().Element(CellStyle).Text(item.GhiChu ?? "");
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container
                                .PaddingVertical(5)
                                .PaddingHorizontal(3)
                                .BorderBottom(1)
                                .BorderColor(Colors.Grey.Lighten2);
                        }
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(text =>
                    {
                        text.Span("Ngày lập: ");
                        text.Span(DateTime.Now.ToString("dd/MM/yyyy")).SemiBold();
                    });
            });
        }).GeneratePdf(filePath);
    }
}
