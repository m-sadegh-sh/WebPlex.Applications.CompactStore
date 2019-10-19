namespace WebPlex.Applications.CompactStore.Extensions {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Helpers;
    using WebPlex.Applications.CompactStore.Models;

    public static class ProductExtensions {
        public static PictureInfo GetListPicture(this ProductModel product) {
            return PictureHelpers.GetList(product);
        }

        public static List<PictureInfo> GetSliderPictures(this ProductModel product) {
            return PictureHelpers.GetSlides(product);
        }
    }
}
