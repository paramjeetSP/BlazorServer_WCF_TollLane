using System.ComponentModel.DataAnnotations;

namespace BlazorServer_WCF.Shared
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }

    public class JurisdictionModel
    {
        public int JurisdictionId { get; set; }
        public string JCode { get; set; }
        public string JName { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }

        [Display(Name = "ISO3166-2")]
        public string ISO3166 { get; set; }
    }
}
