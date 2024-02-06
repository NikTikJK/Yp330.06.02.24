using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace excel.Classes
{
    internal class Subjects
    {
        [JsonPropertyName("pos")]
        public int Pos { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("auditory")]
        public string? Auditory { get; set; }
    }
}
