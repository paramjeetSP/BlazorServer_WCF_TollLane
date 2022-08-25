using BlazorServer_WCF.Shared;

namespace BlazorServer_WCF.Web.Data
{
    public class ImageReviewService
    {
        //ImageReference.IImageReview Service = new ImageReference.ImageReviewClient();
        public List<ImageModel> GetWeatherForecast()
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
