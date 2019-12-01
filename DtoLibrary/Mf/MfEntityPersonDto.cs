using Newtonsoft.Json;

namespace DtoLibrary.Mf
{
    public class MfEntityPersonDto
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "pesel")]
        public string Pesel { get; set; }
        [JsonProperty(PropertyName = "nip")]
        public string Nip { get; set; }
    }
}
