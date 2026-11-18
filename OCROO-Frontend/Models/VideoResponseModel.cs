using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OCROO_Frontend.Models
{
    public class VideoListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("videos")]
        public List<VideoItem> Videos { get; set; } = new();
    }

    public class VideoItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("path")]
        public string Path { get; set; } = "";
    }

}
