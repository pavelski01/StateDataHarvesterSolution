using Newtonsoft.Json;

namespace DtoLibrary.Mf
{
    public class MfResultDto
    {
        [JsonProperty(PropertyName = "subject")]
        public MfSubjectDto Subject { get; set; }
        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }
    }
}
