using DinkToPdf.Contracts;
using System.IO;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using TutorialEx.Models;


namespace TutorialEx.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IConverter _pdfConverter;

        public ShoppingCartController(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public IActionResult DownloadPdf()
        {
            //    var model = new ShoppingCart
            //    {
            //        Id = 1,
            //        Items = new List<CartItem>
            //{
            //    new CartItem { ProductId = 101, ProductName = "IQOO3", Quantity = 32, Price = 25000 },
            //    new CartItem { ProductId = 102, ProductName = "Vivo Z9s", Quantity = 45, Price = 20000 }
            //}
            //    };

            //    return View(model);
            // Generate or get the PDF file data
            var filePath = "D:\\ABHI\\OCS_FAQ_Eligibility_102017.pdf"; // Specify your PDF file path
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Return the file as a Blob with appropriate content type
            return File(fileBytes, "application/pdf", "yourfilename.pdf");

        }

     [HttpPost]
        public IActionResult DownloadPdf(ShoppingCart model)
        {
            // Generate HTML string from model data
            string htmlContent = GenerateHtmlForPdf(model);

            // Configure PDF document settings
            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings =
            {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                Out = null // Set to null to return PDF directly in response
            },
                Objects =
            {
                new ObjectSettings
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            // Convert HTML to PDF
            byte[] pdf = _pdfConverter.Convert(pdfDocument);

            // Return PDF as file download
            return File(pdf, "application/pdf", "ShoppingCart.pdf");

        }
        private string GenerateHtmlForPdf(ShoppingCart model)
        {
            // Create a simple HTML template with the model data
            var html = $@"
    <html>
    <head>
        <style>
            body {{ font-family: Arial, sans-serif; }}
            h1 {{ text-align: center; }}
            table {{ width: 100%; border-collapse: collapse; }}
            th, td {{ border: 1px solid #ccc; padding: 8px; text-align: left; }}
            th {{ background-color: #f2f2f2; }}
        </style>
    </head>
    <body>
        <h1>Shopping Cart</h1>
        <table>
            <thead>
                <tr>
                    <th>Item</th>
                    <th>Quantity</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>";

            foreach (var item in model.Items) // Assuming model.Items is a collection of cart items
            {
                html += $@"
            <tr>
                <td>{item.ProductName}</td>
                <td>{item.Quantity}</td>
                <td>{item.Price:C}</td>
            </tr>";
            }

            html += @"
            </tbody>
        </table>
    </body>
    </html>";

            return html;
        }

    }
}
