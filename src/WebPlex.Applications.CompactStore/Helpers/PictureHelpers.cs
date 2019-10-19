namespace WebPlex.Applications.CompactStore.Helpers {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using T4MVC;
    using WebPlex.Applications.CompactStore.Models;

    public static class PictureHelpers {
        private static readonly string _productsListPath = string.Format("{0}{{0}}/", Uploads.Images.Products.Url(""));
        private static readonly string _productsSlidesLargePath = string.Format("{0}Slides/", _productsListPath);
        private static readonly string _productsSlidesThumbPath = string.Format("{0}_Thumbs/", _productsSlidesLargePath);

        public static string LargeUrlOrDefault(PictureInfo pictureInfo) {
            if (pictureInfo != null && !string.IsNullOrEmpty(pictureInfo.LargeUrl))
                return pictureInfo.LargeUrl;

            return null;
        }

        public static string ThumbUrlOrDefault(PictureInfo pictureInfo) {
            if (pictureInfo != null && !string.IsNullOrEmpty(pictureInfo.ThumbUrl))
                return pictureInfo.ThumbUrl;

            return null;
        }

        public static PictureInfo GetList(ProductModel product) {
            var virtualPath = string.Format(_productsListPath, product.Id);
            var path = HostingEnvironment.MapPath(virtualPath);

            if (string.IsNullOrEmpty(path))
                throw new InvalidOperationException(string.Format(@"Couldn't convert virtual path ""{0}"" to full path.", virtualPath));

            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
                return null;

            if (!directory.GetFiles().Any())
                return null;

            var pictureFile = directory.GetFiles().First();

            return GetPictureFrom(pictureFile, null);
        }

        public static List<PictureInfo> GetSlides(ProductModel product) {
            var largeVirtualPath = string.Format(_productsSlidesLargePath, product.Id);
            var thumbVirtualPath = string.Format(_productsSlidesThumbPath, product.Id);
            var largePath = HostingEnvironment.MapPath(largeVirtualPath);
            var thumbPath = HostingEnvironment.MapPath(thumbVirtualPath);

            if (string.IsNullOrEmpty(largePath))
                throw new InvalidOperationException(string.Format(@"Couldn't convert virtual path ""{0}"" to full path.", largePath));

            if (string.IsNullOrEmpty(thumbPath))
                throw new InvalidOperationException(string.Format(@"Couldn't convert virtual path ""{0}"" to full path.", thumbPath));

            var largeDirectory = new DirectoryInfo(largePath);
            var thumbDirectory = new DirectoryInfo(thumbPath);

            if (!largeDirectory.Exists)
                return null;

            var largePictureFiles = largeDirectory.GetFiles();
            FileInfo[] thumbPictureFiles = null;

            if (thumbDirectory.Exists)
                thumbPictureFiles = thumbDirectory.GetFiles();

            var slidePictures = new List<PictureInfo>();

            for (var index = 0; index < largePictureFiles.Length; index++) {
                var largePicturFile = largePictureFiles[index];
                var thumbPicturFile = thumbPictureFiles != null ? thumbPictureFiles[index] : null;

                slidePictures.Add(GetPictureFrom(largePicturFile, thumbPicturFile));
            }

            return slidePictures;
        }

        private static PictureInfo GetPictureFrom(FileSystemInfo largePictureFile, FileSystemInfo thumbPictureFile) {
            if (largePictureFile == null)
                return null;

            var picture = new PictureInfo {
                LargeUrl = StringHelpers.ConvertPathToUrl(largePictureFile.FullName)
            };

            if (thumbPictureFile != null)
                picture.ThumbUrl = StringHelpers.ConvertPathToUrl(thumbPictureFile.FullName);

            return picture;
        }
    }
}
