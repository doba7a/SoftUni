namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class ExpInboxDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
