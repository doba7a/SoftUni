namespace Instagraph.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class ExportCommentsDto
    {
        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("MostComments")]
        public int MostComments { get; set; }
    }
}
