using Newtonsoft.Json;

namespace DtoLibrary.Mf
{
    public class MfRootObjectDto
    {
        [JsonProperty(PropertyName = "result")]
        public MfResultDto Result { get; set; }
    }
}
