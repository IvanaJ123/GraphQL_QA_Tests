using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiCallDemo1
{
    internal class Lead
    {
        //[JsonPropertyName("id")]
        public int Id { get; set; }
        //[JsonPropertyName("title")]
        public string created_at { get; set; }
        //[JsonPropertyName("completed")]
        public int hasFTD { get; set; }
        public string depositor {  get; set; }
    }
}
