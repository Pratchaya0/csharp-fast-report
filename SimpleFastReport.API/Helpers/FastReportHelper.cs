using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Image;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace SimpleFastReport.API.Helpers
{
    public class FastReportHelper : ControllerBase
    {
        public string ReportsPath { get; private set; }

        public FastReportHelper()
        {
            SetReportsFolder();
        }

        private void SetReportsFolder() => ReportsPath = FindReportsFolder(Environment.CurrentDirectory);

        private string FindReportsFolder(string startDir)
        {
            string directory = Path.Combine(startDir, "Reports");
            if (Directory.Exists(directory))
                return directory;
            for (int i = 0; i < 6; i++)
            {
                startDir = Path.Combine(startDir, "..");
                directory = Path.Combine(startDir, "Reports");
                if (Directory.Exists(directory))
                    return directory;
            }
            throw new Exception("Reports directory is not found");
        }

        public async Task<IActionResult> ExportReport<T>(IEnumerable<T> data, string reportTemplate, string filename, ExportType type, string dataSourceName = "DataSource1")
        {
            var report = new Report();
            report.Load(Path.Combine(ReportsPath, reportTemplate));
            report.RegisterData(data, dataSourceName);
            report.Prepare();

            using (MemoryStream ms = new MemoryStream())
            {
                switch (type)
                {

                    case ExportType.PDF:
                        FastReport.Export.PdfSimple.PDFSimpleExport pdf = new FastReport.Export.PdfSimple.PDFSimpleExport();
                        report.Export(pdf, ms);
                        return File(ms.ToArray(), "application/pdf", $"{filename}.pdf");

                    case ExportType.HTML:
                        HTMLExport html = new HTMLExport();
                        report.Export(html, ms);
                        return File(ms.ToArray(), "text/html", $"{filename}.html");

                    case ExportType.JPEG:
                    case ExportType.PNG:
                        ImageExport image = new ImageExport();
                        image.ImageFormat = GetImageFormat(type);
                        report.Export(image, ms);
                        return File(ms.ToArray(), GetMimeType(type), $"{filename}.{type.ToString().ToLower()}");

                    default:
                        return BadRequest("Unsupported export type");

                }
            }
        }

        private ImageExportFormat GetImageFormat(ExportType type)
        {
            switch (type)
            {
                case ExportType.JPEG: return ImageExportFormat.Jpeg;
                case ExportType.PNG: return ImageExportFormat.Png;
                default: throw new ArgumentException("Invalid image export type");
            }
        }

        private string GetMimeType(ExportType type)
        {
            switch (type)
            {
                case ExportType.JPEG: return "image/jpeg";
                case ExportType.PNG: return "image/png";
                default: throw new ArgumentException("Invalid image export type");
            }
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExportType
    {
        Excel = 0,
        PDF = 1,
        HTML = 2,
        JPEG = 3,
        PNG = 4,
        PDFProtected = 5
    }

}
