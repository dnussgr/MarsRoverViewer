using System.Text.Json.Serialization;


namespace MarsRoverViewer.Models
{
    public class Photo
    {
        [JsonPropertyName("img_src")]
        public string ImgSrc { get; set; }

        [JsonPropertyName("camera")]
        public Camera Camera { get; set; }

        public Photo(string imgSrc, Camera camera)
        {
            ImgSrc = imgSrc;
            Camera = camera;
        }
    }
}
