using Stimulsoft.Base;
using Stimulsoft.Reports.Engine.NetCore.PdfExpoerter;



var allFont = Directory.GetFiles($@"D:\Stimul\Stimulsoft.Report.Engine.NetCore.PdfExporter\StimulsoftPdfExporterSample\Fonts");
//var mainMrtSample = File.ReadAllLines($@"D:\Stimul\Stimulsoft.Report.Engine.NetCore.PdfExporter\StimulsoftPdfExporterSample\MrtFiles\Report.mrt");
//var newMrtFile = "";
//foreach (var font in allFont)
//{
//    var fontBytes = File.ReadAllBytes(font);
//    StiFontCollection.AddFontBytes(fontBytes);
//    var fontName = StiFontCollection.Instance.Families.Last().Name;
//    newMrtFile = "";
//    foreach (var item in mainMrtSample)
//    {
//        if (item.Contains("<Font"))
//        {
//            newMrtFile += $"              <Font>{fontName},12</Font>" + Environment.NewLine;
//        }
//        else
//        {
//            newMrtFile += item + Environment.NewLine;
//        }
//    }
//    try
//    {

//        File.WriteAllText(@$"D:\Stimul\Stimulsoft.Report.Engine.NetCore.PdfExporter\StimulsoftPdfExporterSample\MrtFiles\Report-{fontName}.mrt", newMrtFile);
//    }
//    catch (Exception)
//    {

//    }
//}




//var allFontss = Directory.GetFiles($@"C:\Users\Phoenix\Desktop\Fonts");

//var allSuportedPdf = Directory.GetFiles($@"C:\Users\Phoenix\Desktop\Support");
//var text = "";
//foreach (var font in allFontss)
//{
//    var fontBytes = File.ReadAllBytes(font);
//    StiFontCollection.AddFontBytes(fontBytes);
//    var fontName = StiFontCollection.Instance.Families.Last().Name;
//    if (!allSuportedPdf.Any(_ => Path.GetFileName(_).Split(".").First() == fontName))
//    {
//        try
//        {
//            text += Path.GetFileName(font) + Environment.NewLine;

//        }
//        catch (Exception)
//        {
//        }
//    }

//}
//var allFontss2 = Directory.GetFiles($@"C:\Users\Phoenix\Desktop\Fonts");





var datas = new List<dynamic>()
{
    "متن اول به زبان فارسی",
    "AAA",
    "123",
    "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی و فرهنگ پیشرو در زبان فارسی ایجاد کرد. در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.",
    "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی و فرهنگ پیشرو در زبان فارسی ایجاد کرد. در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد."
};


foreach (var font in allFont)
{
    try
    {
        var fontBytes = File.ReadAllBytes(font);
        StiFontCollection.AddFontBytes(fontBytes);
        var fontName = StiFontCollection.Instance.Families.Last().Name;
        var mrtFileContent = File.ReadAllBytes($@"D:\Stimul\Stimulsoft.Report.Engine.NetCore.PdfExporter\StimulsoftPdfExporterSample\MrtFiles\Report-{fontName}.mrt");

        ExporterTools.StartReport()
                     .AddFontBytes(fontBytes)
                     .SetMrtFile(mrtFileContent)
                     .AddDataContentAsBusinessObject("Datas", datas)
                     .RenderWithBusinessObjectDataMode()
                     .ExportPdfToPath($@"C:\Users\Phoenix\Desktop\AllPdf\{fontName}.pdf");
    }
    catch (Exception)
    {
    }

}













