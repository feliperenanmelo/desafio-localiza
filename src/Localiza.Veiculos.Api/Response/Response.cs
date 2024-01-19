using Newtonsoft.Json;

namespace Localiza.Veiculos.Api.Response
{
    public class ResponseRequest
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }

        [JsonProperty("dados")]
        public object? Data { get; set; }

        [JsonProperty("erros")]
        public IEnumerable<string> Erros { get; set; }

        public ResponseRequest(int statusCode, bool sucesso, object data = null, IEnumerable<string> erros = null)
        {
            StatusCode = statusCode;
            Sucesso = sucesso;
            Data = data;
            Erros = erros;
        }
    }
}
