using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace excel.Classes
{
    internal class Class
    {
        [JsonPropertyName("target")]
        public string? Target {  get; set; }

        [JsonPropertyName("workdays")]
        public List<WorksDay>? WorksDay { get; set; }
    }
}
