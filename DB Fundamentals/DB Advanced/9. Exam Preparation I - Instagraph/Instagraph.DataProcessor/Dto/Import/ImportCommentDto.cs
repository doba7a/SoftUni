﻿namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class ImportCommentDto
    {
        [Required]
        [MaxLength(250)]
        [XmlElement("content")]
        public string Content { get; set; }

        [Required]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("post")]
        public ImportCommentPostDto PostId { get; set; }
    }
}
