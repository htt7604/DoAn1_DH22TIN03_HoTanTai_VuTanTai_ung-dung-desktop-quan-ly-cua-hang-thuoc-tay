using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

namespace QL_Nha_thuoc.BaoCao
{
    public class BaoCao<T> : IDocument
    {
        private readonly List<T> danhSach;
        private readonly string tieuDe;
        private readonly List<(string Header, Func<T, string> ValueSelector, decimal? Width)> cotDanhSach;
        private readonly DateTime? ngayBaoCao;

        public BaoCao(List<T> danhSach, string tieuDe, List<(string Header, Func<T, string> ValueSelector, decimal? Width)> cotDanhSach, DateTime? ngayBaoCao = null)
        {
            this.danhSach = danhSach;
            this.tieuDe = tieuDe;
            this.cotDanhSach = cotDanhSach;
            this.ngayBaoCao = ngayBaoCao;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header()
                    .Text(ngayBaoCao.HasValue ? $"{tieuDe} - {ngayBaoCao:dd/MM/yyyy}" : tieuDe)
                    .FontSize(18)
                    .Bold()
                    .AlignCenter();

                page.Content()
                    .Table(table =>
                    {
                        // Định nghĩa cột
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var cot in cotDanhSach)
                            {
                                if (cot.Width.HasValue)
                                    columns.ConstantColumn((float)cot.Width.Value);
                                else
                                    columns.RelativeColumn();
                            }
                        });

                        // Header
                        table.Header(header =>
                        {
                            foreach (var cot in cotDanhSach)
                            {
                                header.Cell().Element(CellStyle).Text(cot.Header);
                            }
                        });

                        // Dữ liệu từng dòng
                        foreach (var item in danhSach)
                        {
                            foreach (var cot in cotDanhSach)
                            {
                                var text = cot.ValueSelector(item) ?? "";
                                table.Cell().Element(CellStyle).Text(text);
                            }
                        }
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(text =>
                    {
                        text.Span("Trang ");
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
            });
        }

        private IContainer CellStyle(IContainer container)
        {
            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
        }

        public void GeneratePdf(string filePath)
        {
            Document.Create(container => Compose(container))
                    .GeneratePdf(filePath);
        }
    }
}
