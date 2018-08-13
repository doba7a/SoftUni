﻿namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        public Animal()
        {
            this.Procedures = new HashSet<Procedure>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        public string PassportSerialNumber { get; set; }
        [Required]
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
