using Infrastructure.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Infrastructure.Reportes
{
    public class HistorialAcademicoReport : IDocument
    {
        private readonly HistorialAcademicoDataSource _dataSource;

        public HistorialAcademicoReport(HistorialAcademicoDataSource dataSource)
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
                    column.Item().Text("Reporte: Historial Académico")
                        .Style(TextStyle.Default.FontSize(20).SemiBold().Color(Colors.Blue.Medium));
                    column.Item().Text($"Alumno: {_dataSource.NombreCompletoAlumno} (Legajo: {_dataSource.Legajo})")
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
                column.Item().Element(ComposeTable);
                column.Item().PaddingTop(20).AlignRight().Text(_dataSource.PromedioGeneral).SemiBold();
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(1);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(1);
                });

                table.Header(header =>
                {
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Materia").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Comisión").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Año").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Condición").Bold();
                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Nota").Bold();
                });

                foreach (var cursada in _dataSource.Cursadas)
                {
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cursada.Materia);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cursada.Comision);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cursada.Anio.ToString());
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cursada.Condicion);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cursada.Nota.ToString());
                }
            });
        }
    }
}