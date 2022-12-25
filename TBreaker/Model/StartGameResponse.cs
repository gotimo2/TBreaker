using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TBreaker.Model
{
    [Serializable]
    public class StartGameResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
