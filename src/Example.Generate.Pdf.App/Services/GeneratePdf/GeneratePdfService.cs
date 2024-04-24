using Example.Generate.Pdf.App.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Example.Generate.Pdf.App.Services.GeneratePdf;

public class GeneratePdfService
{
    public GeneratePdfService()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        QuestPDF.Settings.EnableDebugging = true;
    }

    public Task<byte[]> GenerateTradingStatementAsync(Order order, CancellationToken cancellationToken = default)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                int number = 1;

                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header()
                    .AlignCenter()
                    .Text("Trading Statement")
                    .SemiBold()
                    .FontSize(24);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(4);
                            });

                            table.Cell().Row(1).Column(1).Text(nameof(order.Customer.FullName));
                            table.Cell().Row(1).Column(2).Text(order.Customer.FullName);

                            table.Cell().Row(2).Column(1).Text(nameof(order.Customer.PhoneNumber));
                            table.Cell().Row(2).Column(2).Text(order.Customer.PhoneNumber);
                        });


                        column.Item().Border(1)
                            .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                // sequential number
                                columns.RelativeColumn(1);
                                // name
                                columns.RelativeColumn(3);
                                // price
                                columns.RelativeColumn(2);
                                // quantity
                                columns.RelativeColumn(2);
                                // total price
                                columns.RelativeColumn(2);
                                // note
                                columns.RelativeColumn(3);
                            });

                            uint row = 1;
                            int cellPadding = 6;
                            string tableHearderColor = Colors.Grey.Lighten3;
                            // string tableFooterColor = Colors.Grey.Lighten4;

                            table.Header(x =>
                            {
                                x.Cell().Row(row).Column(1).Background(tableHearderColor).AlignCenter().Padding(cellPadding).Text("#");
                                x.Cell().Row(row).Column(2).Background(tableHearderColor).Padding(cellPadding).Text(nameof(OrderDetail.Name));
                                x.Cell().Row(row).Column(3).Background(tableHearderColor).Padding(cellPadding).AlignRight().Text(nameof(OrderDetail.Price));
                                x.Cell().Row(row).Column(4).Background(tableHearderColor).Padding(cellPadding).AlignCenter().Text(nameof(OrderDetail.Quantity));
                                x.Cell().Row(row).Column(5).Background(tableHearderColor).Padding(cellPadding).AlignRight().Text(nameof(OrderDetail.TotalPrice));
                                x.Cell().Row(row).Column(6).Background(tableHearderColor).Padding(cellPadding).Text(nameof(OrderDetail.Note));
                            });

                            row += 1;

                            if (order.Details.Any())
                            {

                                foreach (var orderDetail in order.Details)
                                {
                                    table.Cell().Row(row).Column(1).Padding(cellPadding).AlignCenter().Text($"{number}");
                                    table.Cell().Row(row).Column(2).Padding(cellPadding).Text(orderDetail.Name);
                                    table.Cell().Row(row).Column(3).Padding(cellPadding).AlignRight().Text($"{orderDetail.Price:f2}");
                                    table.Cell().Row(row).Column(4).Padding(cellPadding).AlignCenter().Text($"{orderDetail.Quantity:n0}");
                                    table.Cell().Row(row).Column(5).Padding(cellPadding).AlignRight().Text($"{orderDetail.TotalPrice:f2}");
                                    table.Cell().Row(row).Column(6).Padding(cellPadding).Text(orderDetail.Note ?? string.Empty);

                                    number += 1;
                                    row += 1;
                                }

                                // table.Footer(x =>
                                // {
                                //     x.Cell().Row(row).ColumnSpan(4).Background(tableFooterColor).Padding(cellPadding).AlignCenter().Text("Total");
                                //     x.Cell().Row(row).Column(5).Background(tableFooterColor).Padding(cellPadding).AlignRight().Text($"{order.Details.Sum(x => x.TotalPrice):f2}");
                                //     x.Cell().Row(row).Column(6).Background(tableFooterColor).Padding(cellPadding).Text(string.Empty);
                                // });
                            }
                            else
                            {
                                table.Cell().ColumnSpan(6).Padding(cellPadding).AlignCenter().Text("No data");
                            }
                        });

                    });


                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });

            });
        });

        return Task.FromResult(document.GeneratePdf());
    }
}
