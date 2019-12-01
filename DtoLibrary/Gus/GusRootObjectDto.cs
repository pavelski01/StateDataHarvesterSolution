using System.Xml.Serialization;

namespace DtoLibrary.Gus
{
    [XmlRoot("root")]
    public class GusRootObjectDto
    {
        [XmlElement("dane")]
        public GusDataDto Data { get; set; }
    }
}
