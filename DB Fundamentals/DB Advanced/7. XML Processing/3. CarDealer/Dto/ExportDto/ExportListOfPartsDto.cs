namespace CarDealer.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class ExportListOfPartsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public string Price { get; set; }
    }
}
