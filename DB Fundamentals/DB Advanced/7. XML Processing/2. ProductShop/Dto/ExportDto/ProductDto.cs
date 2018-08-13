namespace ProductShop.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}