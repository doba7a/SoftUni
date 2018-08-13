namespace ProductShop.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlRoot("users")]
    public class UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlArray("user")]
        public UserDto[] Users { get; set; }
    }
}
