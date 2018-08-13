namespace CarDealer.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithListOfPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportListOfPartsDto[] ListOfParts { get; set; }
    }
}
