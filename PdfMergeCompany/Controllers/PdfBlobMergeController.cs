using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace PdfMergeCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfBlobMergeController : ControllerBase
    {
        [HttpPost("merge-all-companies")]
        public IActionResult MergeAllCompanyPdfs()
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var inputDir = Path.Combine(basePath, "pdfs");
            var outputDir = Path.Combine(basePath, "merged");

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var companyDirs = Directory.GetDirectories(inputDir);

            var mergedResults = new List<object>();

            foreach (var companyPath in companyDirs)
            {
                var companyName = Path.GetFileName(companyPath);
                var pdfFiles = Directory.GetFiles(companyPath, "*.pdf");

                if (pdfFiles.Length < 1)
                    continue;

                var outputDocument = new PdfDocument();

                foreach (var filePath in pdfFiles)
                {
                    using var stream = System.IO.File.OpenRead(filePath);
                    var inputDoc = PdfReader.Open(stream, PdfDocumentOpenMode.Import);
                    for (int i = 0; i < inputDoc.PageCount; i++)
                    {
                        outputDocument.AddPage(inputDoc.Pages[i]);
                    }
                }

                var mergedFileName = $"{companyName}_merged.pdf";
                var outputPath = Path.Combine(outputDir, mergedFileName);
                outputDocument.Save(outputPath);

                var fileUrl = $"{Request.Scheme}://{Request.Host}/merged/{mergedFileName}";
                mergedResults.Add(new
                {
                    company = companyName,
                    file = mergedFileName,
                    url = fileUrl
                });
            }

            return Ok(mergedResults);
        }
    }
}
