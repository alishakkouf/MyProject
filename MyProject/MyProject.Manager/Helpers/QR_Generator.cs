using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace MyProject.Manager.Helpers
{
    public static class QR_Generator
    {
        public static byte[] GenerateQRCode<T>
            (T data) where T : class
        {
            var QrCodeInfo = new QRCodeGenerator().CreateQrCode($"{data}", QRCodeGenerator.ECCLevel.Q);

            var bitmapArray = new BitmapByteQRCode(QrCodeInfo).GetGraphic(10);

            return bitmapArray;
        }
    }
}
