namespace ProductShop.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserSoldProductDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
