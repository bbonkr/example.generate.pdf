// See https://aka.ms/new-console-template for more information
using Example.Generate.Pdf.App.Services.ExampleData;
using Example.Generate.Pdf.App.Services.GeneratePdf;

Console.WriteLine("Starting to generate PDF...");

var exampleDataService = new ExampleDataService();
var generatePdfService = new GeneratePdfService();

var order = exampleDataService.GetExampleData();

var pdfBinary = await generatePdfService.GenerateTradingStatementAsync(order);

var pdfFileName = $"example-{DateTime.UtcNow:yyyy-MM-ddTHHmmss}.pdf";

var exampleDirectory = Path.Combine("../..", "pdf");
var exampleDirectoryPath = Path.GetFullPath(exampleDirectory);
if (!Directory.Exists(exampleDirectoryPath))
{
    Directory.CreateDirectory(exampleDirectoryPath);
}

var pdfFilePath = Path.Combine(exampleDirectoryPath, pdfFileName);
pdfFilePath = Path.GetFullPath(pdfFilePath);

using var stream = File.Create(pdfFilePath);
await stream.WriteAsync(pdfBinary, 0, pdfBinary.Length);
await stream.FlushAsync();


Console.WriteLine($"Done. ({pdfFilePath})");