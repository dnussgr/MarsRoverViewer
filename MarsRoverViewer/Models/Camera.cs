using System.Text.Json.Serialization;

namespace MarsRoverViewer.Models
{
    public class Camera
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        public Camera(string fullName)
        {
            FullName = fullName;
        }
    }
}
