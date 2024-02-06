using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace excel.Classes
{
    internal class WorksDay
    {
        [JsonPropertyName("pos")]
        public int Pos {  get; set; }

        [JsonPropertyName("subjects")]
        public List<Subjects>? Subjects { get; set; }
    }
}
