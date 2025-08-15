using System;
using System.Collections.Generic;
using System.Globalization;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    public class HoaDonTraHangModel
    {
        public DateTime NgayBan { get; set; } = DateTime.Now;
        public string KhachHang { get; set; } = "Khách lẻ";
        public string DiaChi { get; set; } = "";
        public string KhuVuc { get; set; } = "";
        public string NguoiBan { get; set; } = "";
        public List<HoaDonItem> Items { get; set; } = new List<HoaDonItem>();
        public decimal TongTien { get; set; }
        public decimal TienTraKhach { get; set; }
        public string FooterUrl { get; set; } = "";
    }

    public class HoaDonItem
    {
        public string Ten { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien => DonGia * SoLuong;
    }

    internal class HoaDonTraHangDocument : IDocument
    {
        private readonly HoaDonTraHangModel _model;

        public HoaDonTraHangDocument(HoaDonTraHangModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(32);
                page.PageColor(Colors.White);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(t =>
                {
                    if (!string.IsNullOrWhiteSpace(_model.FooterUrl))
                        t.Line(_model.FooterUrl).FontSize(8);
                });
            });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Text($"Ngày bán: {_model.NgayBan:dd 'tháng' MM 'năm' yyyy}")
                      .FontSize(10);

                column.Item().PaddingTop(6).AlignCenter()
                      .Text("HÓA ĐƠN TRẢ HÀNG")
                      .FontSize(14)
                      .SemiBold();

                // Dòng kẻ ngang
                column.Item().PaddingVertical(6).LineHorizontal(1).LineColor(Colors.Black);

                // Thông tin khách hàng
                column.Item().Row(row =>
                {
                    row.RelativeColumn().Column(col =>
                    {
                        col.Item().Text($"Khách hàng: {_model.KhachHang}").FontSize(10);
                        col.Item().Text($"Địa chỉ: {_model.DiaChi}").FontSize(10);
                        col.Item().Text($"Khu vực: {_model.KhuVuc}").FontSize(10);
                        col.Item().Text($"Người bán: {_model.NguoiBan}").FontSize(10);
                    });
                });
            });
        }


        private void ComposeContent(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(6);
                        columns.ConstantColumn(40);
                        columns.ConstantColumn(120);
                    });

                    // Header
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Đơn giá").FontSize(10).SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("SL").FontSize(10).SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Thành tiền").FontSize(10).SemiBold();
                    });

                    // Items
                    foreach (var item in _model.Items)
                    {
                        table.Cell().Element(CellStyle).Column(col =>
                        {
                            col.Item().Text(item.Ten).FontSize(10);
                            col.Item().Text(FormatCurrency(item.DonGia)).FontSize(9);
                        });

                        table.Cell().Element(CellStyle).AlignCenter().Text(item.SoLuong.ToString()).FontSize(10);
                        table.Cell().Element(CellStyle).AlignRight().Text(FormatCurrency(item.ThanhTien)).FontSize(10);
                    }
                });

                // Totals
                column.Item().PaddingTop(10).AlignRight().Column(c =>
                {
                    c.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Tổng tiền hàng trả:").FontSize(10);
                        r.ConstantColumn(120).AlignRight().Text(FormatCurrency(_model.TongTien)).FontSize(10);
                    });

                    c.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Tiền trả khách").FontSize(10);
                        r.ConstantColumn(120).AlignRight().Text(FormatCurrency(_model.TienTraKhach)).FontSize(10);
                    });
                });
            });
        }

        private static IContainer CellStyle(IContainer container)
        {
            return container.PaddingVertical(4).PaddingHorizontal(6);
        }

        private static string FormatCurrency(decimal value)
        {
            return value.ToString("N0", new CultureInfo("vi-VN"));
        }
    }
}
