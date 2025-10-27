using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Infrastructure.Reportes
{
    public class RendimientoReport : IDocument
    {
        private readonly RendimientoDataSource _dataSource;

        public RendimientoReport(RendimientoDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Página ");
                    text.CurrentPageNumber();
                    text.Span(" de ");
                    text.TotalPages();
                });
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("Reporte de Rendimiento Académico")
                        .Style(TextStyle.Default.FontSize(20).SemiBold().Color(Colors.Blue.Medium));

                    column.Item().Text($"Curso: {_dataSource.NombreCurso}")
                        .Style(TextStyle.Default.FontSize(12));

                    column.Item().Text(System.DateTime.Now.ToString("dd/MM/yyyy"))
                        .Style(TextStyle.Default.FontSize(9).Light());
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Column(column =>
            {
                if (_dataSource.GraficoBytes != null && _dataSource.GraficoBytes.Length > 0)
                {
                    column.Item().AlignCenter().Width(400).Height(250).Image(_dataSource.GraficoBytes);
                    column.Item().PaddingTop(20);
                }

                column.Item().Element(ComposeTable);
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(1);
                });

                table.Header(header =>
                {
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Legajo").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Nombre Completo").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Condición").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Nota").Bold();
                });

                foreach (var alumno in _dataSource.Alumnos)
                {
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.LegajoAlumno);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.NombreCompleto);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.Condicion);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.Nota.ToString());
                }
            });
        }
    }
}