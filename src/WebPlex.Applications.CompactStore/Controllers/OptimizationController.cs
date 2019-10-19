namespace WebPlex.Applications.CompactStore.Controllers {
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Properties;
    using IOFile = System.IO.File;
    using DrawingImage = System.Drawing.Image;

    public partial class OptimizationController : StoreController {
        [HttpGet]
        [OutputCache(CacheProfile = "Optimization-Image")]
        public virtual ActionResult Image(int maximumWidth, int maximumHeight, string relativeUrl) {
            relativeUrl = string.Format("/{0}", relativeUrl);

            var path = Server.MapPath(relativeUrl);
            var fileName = Path.GetFileName(path) ?? "";
            var contentType = MimeMapping.GetMimeMapping(fileName);

            if (!IOFile.Exists(path))
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Image);

            using (var originalImage = DrawingImage.FromFile(path)) {
                var originalWidth = originalImage.Width;
                var originalHeight = originalImage.Height;

                var ratioX = maximumWidth/(float) originalWidth;
                var ratioY = maximumHeight/(float) originalHeight;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int) (originalWidth*ratio);
                var newHeight = (int) (originalHeight*ratio);

                var optimizedImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

                using (var graphics = Graphics.FromImage(optimizedImage)) {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                }

                var originalFormat = ImageCodecInfo.GetImageDecoders().Single(ici => ici.FormatID == originalImage.RawFormat.Guid);

                var encoderParameters = new EncoderParameters(1) {
                    Param = new[] {new EncoderParameter(Encoder.Quality, 100)}
                };

                using (var stream = new MemoryStream()) {
                    optimizedImage.Save(stream, originalFormat, encoderParameters);

                    return File(stream.ToArray(), contentType, fileName);
                }
            }
        }
    }
}
