using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DtoLibrary.Mf
{
    public class MfSubjectDto
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Today;
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "nip")]
        public string Nip { get; set; }
        [JsonProperty(PropertyName = "statusVat")]
        public string StatusVat { get; set; }
        [JsonProperty(PropertyName = "regon")]
        public string Regon { get; set; }
        [JsonProperty(PropertyName = "pesel")]
        public string Pesel { get; set; }
        [JsonProperty(PropertyName = "krs")]
        public string Krs { get; set; }
        [JsonProperty(PropertyName = "residenceAddress")]
        public string ResidenceAddress { get; set; }
        [JsonProperty(PropertyName = "workingAddress")]
        public string WorkingAddress { get; set; }
        [JsonProperty(PropertyName = "representatives")]
        public List<MfEntityPersonDto> Representatives { get; set; }
        [JsonProperty(PropertyName = "authorizedClerks")]
        public List<MfEntityPersonDto> AuthorizedClerks { get; set; }
        [JsonProperty(PropertyName = "partners")]
        public List<MfEntityPersonDto> Partners { get; set; }
        [JsonProperty(PropertyName = "registrationLegalDate")]
        public string RegistrationLegalDate { get; set; }
        [JsonProperty(PropertyName = "registrationDenialBasis")]
        public string RegistrationDenialBasis { get; set; }
        [JsonProperty(PropertyName = "registrationDenialDate")]
        public string RegistrationDenialDate { get; set; }
        [JsonProperty(PropertyName = "restorationBasis")]
        public string RestorationBasis { get; set; }
        [JsonProperty(PropertyName = "restorationDate")]
        public string RestorationDate { get; set; }
        [JsonProperty(PropertyName = "removalBasis")]
        public string RemovalBasis { get; set; }
        [JsonProperty(PropertyName = "removalDate")]
        public string RemovalDate { get; set; }
        [JsonProperty(PropertyName = "accountNumbers")]
        public List<string> AccountNumbers { get; set; }
        [Column("AccountNumbers")]
        public string AccountNumbersAsString
        {
            get { return string.Join(";", AccountNumbers); }
            set { AccountNumbers = value.Split(';').ToList(); }
        }
        [JsonProperty(PropertyName = "hasVirtualAccounts")]
        public bool HasVirtualAccounts { get; set; }
    }
}
