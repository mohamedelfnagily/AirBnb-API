using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AirBnb.BL.Helpers
{
    public class QRCodeHelper
    {
        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public byte[] GenerateQRCode(string QRCodeText)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode(QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(data);
            Image qrImage = qrCode.GetGraphic(20);
            var bytes = ImageToByteArray(qrImage);
            return bytes;
        }
    }
}
