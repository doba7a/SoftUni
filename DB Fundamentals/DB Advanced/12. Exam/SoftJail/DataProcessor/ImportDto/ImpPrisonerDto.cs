namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ImpPrisonerDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
