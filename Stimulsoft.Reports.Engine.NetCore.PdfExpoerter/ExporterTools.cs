using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using System.Drawing;

namespace Stimulsoft.Reports.Engine.NetCore.PdfExpoerter
{
    public class StiExporterTools
    {
        public StiExporterTools()
        {
            DataContents = new Dictionary<string, dynamic>();
            Fonts = new List<byte[]>();
        }

        public Dictionary<string, dynamic> DataContents { get; private set; }
        public List<byte[]> Fonts { get; private set; }
        public byte[] MrtFileContent { get; set; }
        public string StimulsoftLicenseKey { get; set; } = default;

    }

    public static class ExporterTools
    {
        public static StiExporterTools StartReport()
        {
            return new StiExporterTools();
        }
        public static StiExporterTools SetLicenseKey(
            this StiExporterTools tools,  
            string licenseKey)
        {
            StiLicense.LoadFromString(licenseKey);
            return tools;
        }

        public static StiExporterTools AddFontBytes(
            this StiExporterTools tools,
            byte[] font,
            string? alias = null,
            FontStyle? fontStyle = null)
        {
            try
            {
                StiFontCollection
                    .AddFontBytes(
                        font,
                        alias,
                        fontStyle);

                tools.Fonts.Add(font);
            }
            catch
            {
                throw;
            }

            return tools;
        }

        public static StiExporterTools AddDataContentAsBusinessObject(
          this StiExporterTools tools,
          string name,
          dynamic data)
        {
            try
            {
                tools.DataContents.Add(name, data);
            }
            catch
            {
                throw;
            }

            return tools;
        }

        public static StiExporterTools SetMrtFile(
            this StiExporterTools tools,
            byte[] mrtFileBytes)
        {
            try
            {
                tools.MrtFileContent = mrtFileBytes;
            }
            catch
            {
                throw;
            }

            return tools;
        }

        public static StiReport RenderWithBusinessObjectDataMode(
            this StiExporterTools tools,
            bool showProgressState = false)
        {
            var report = new StiReport();
            report.Load(tools.MrtFileContent);

            report.RegBusinessObject(
                tools.DataContents
                     .Select(_ => new StiBusinessObjectData(null, _.Key, _.Value))
                     .ToList());

            report.Render(showProgressState);

            return report;
        }

        public static void ExportPdfToPath(this StiReport report, string absolutePath)
        {
            report.ExportDocument(StiExportFormat.Pdf, absolutePath);
        }

        public static Stream ExportPdfAsMemoryStream(this StiReport report, StiExportSettings settings)
        {
            settings ??= new StiPdfExportSettings();

            var memoryStream = new MemoryStream();
            report.ExportDocument(StiExportFormat.Pdf, memoryStream, settings);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public static Stream ExportPdfAsCustomStream(
            this StiReport report,
            Stream customStream,
            StiExportSettings settings)
        {
            settings ??= new StiPdfExportSettings();

            report.ExportDocument(StiExportFormat.Pdf, customStream, settings);
            customStream.Seek(0, SeekOrigin.Begin);
            return customStream;
        }
    }
}
