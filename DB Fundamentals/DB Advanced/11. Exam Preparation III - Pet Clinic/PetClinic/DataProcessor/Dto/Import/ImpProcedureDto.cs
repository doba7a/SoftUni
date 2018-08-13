namespace PetClinic.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImpProcedureDto
    {
        [XmlElement("Vet")]
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Vet { get; set; }

        [XmlElement("Animal")]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        [Required]
        public ImpProcedureAnimalAidDto[] AnimalAids { get; set; }
    }
}
