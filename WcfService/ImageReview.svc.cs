using System.Collections.Generic;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageReview" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageReview.svc or ImageReview.svc.cs at the Solution Explorer and start debugging.
    public class ImageReview : IImageReview
    {
        public IEnumerable<ImageModel> GetImages()
        {
            var images = new List<ImageModel>();

            for (int i = 1; i < 13; i++)
            {
                images.Add(new ImageModel { Id = i, Path = $"images/{i}.jpg" });
            }

            return images;
        }
    }
}
