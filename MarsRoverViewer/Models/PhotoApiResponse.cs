using System.Text.Json.Serialization;

namespace MarsRoverViewer.Models
{
    public class PhotoApiResponse
    {
        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }

        public PhotoApiResponse(List<Photo> photos)
        {
            Photos = photos;
        }
    }
}
