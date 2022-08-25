using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImageReview" in both code and config file together.
    [ServiceContract]
    public interface IImageReview
    {
        [OperationContract]
        IEnumerable<ImageModel> GetImages();
    }
}
