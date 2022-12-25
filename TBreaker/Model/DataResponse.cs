using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace TBreaker.Model
{
    [Serializable]
    public class DataResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        public override string ToString()
        {
            return $"is data null? {(Data == null? 'y' : 'n')  }";
        }

    }
}
