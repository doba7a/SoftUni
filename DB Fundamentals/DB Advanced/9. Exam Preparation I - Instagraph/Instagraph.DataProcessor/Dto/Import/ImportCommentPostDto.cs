namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class ImportCommentPostDto
    {
        [Required]
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}