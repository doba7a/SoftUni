namespace ProductShop.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("sold-products")]
    public class ProductsDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public ProductDto[] Product { get; set; }
    }
}
