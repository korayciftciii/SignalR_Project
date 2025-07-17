using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QRController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ViewBag.QRImage = null;
                return View();
            }

            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q))
                {
                    var bitmapQrCode = new BitmapByteQRCode(qrData);
                    byte[] qrCodeBytes = bitmapQrCode.GetGraphic(10);
                    string base64 = Convert.ToBase64String(qrCodeBytes);
                    ViewBag.QRImage = $"data:image/png;base64,{base64}";
                }
            }
            return View();
        }
    }
}
