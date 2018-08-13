namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dto.Import;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string ImportAnimalAidMessage = "Record {0} successfully imported.";
        private const string ImportAnimalMessage = "Record {0} Passport №: {1} successfully imported.";
        private const string ImportVetMessage = "Record {0} successfully imported.";
        private const string ImportProcedureMessage = "Record successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImpAnimalAidDto[] impAnimalAidDtos = JsonConvert.DeserializeObject<ImpAnimalAidDto[]>(jsonString);
            List<AnimalAid> validAnimalAids = new List<AnimalAid>();

            foreach (ImpAnimalAidDto impAnimalDto in impAnimalAidDtos)
            {
                if (!IsValid(impAnimalDto) 
                    || validAnimalAids.Any(aa => aa.Name == impAnimalDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                AnimalAid animalAid = new AnimalAid()
                {
                    Name = impAnimalDto.Name,
                    Price = impAnimalDto.Price
                };

                validAnimalAids.Add(animalAid);
                sb.AppendLine(string.Format(ImportAnimalAidMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImpAnimalDto[] impAnimalDtos = JsonConvert.DeserializeObject<ImpAnimalDto[]>(jsonString);
            List<Animal> validAnimals = new List<Animal>();
            List<string> registeredSerialNumbers = new List<string>();

            foreach (ImpAnimalDto impAnimalDto in impAnimalDtos)
            {
                if (!IsValid(impAnimalDto)
                    || !IsValid(impAnimalDto.Passport)
                    || registeredSerialNumbers.Any(p => p == impAnimalDto.Passport.SerialNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Animal animal = new Animal()
                {
                    Name = impAnimalDto.Name,
                    Type = impAnimalDto.Type,
                    Age = impAnimalDto.Age,
                    Passport = new Passport()
                    {
                        SerialNumber = impAnimalDto.Passport.SerialNumber,
                        OwnerName = impAnimalDto.Passport.OwnerName,
                        OwnerPhoneNumber = impAnimalDto.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(impAnimalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    }
                };

                validAnimals.Add(animal);
                registeredSerialNumbers.Add(impAnimalDto.Passport.SerialNumber);

                sb.AppendLine(string.Format(ImportAnimalMessage, animal.Name, animal.Passport.SerialNumber));
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImpVetDto[]), new XmlRootAttribute("Vets"));
            ImpVetDto[] impVetDtos = (ImpVetDto[])serializer.Deserialize(new StringReader(xmlString));
            List<Vet> validVets = new List<Vet>();

            foreach (ImpVetDto impVetDto in impVetDtos)
            {
                if (!IsValid(impVetDto)
                    || validVets.Any(v => v.PhoneNumber == impVetDto.PhoneNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Vet vet = new Vet()
                {
                    Name = impVetDto.Name,
                    Profession = impVetDto.Profession,
                    Age = impVetDto.Age,
                    PhoneNumber = impVetDto.PhoneNumber
                };

                validVets.Add(vet);

                sb.AppendLine(string.Format(ImportVetMessage, vet.Name));
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImpProcedureDto[]), new XmlRootAttribute("Procedures"));
            ImpProcedureDto[] impProcedureDtos = (ImpProcedureDto[])serializer.Deserialize(new StringReader(xmlString));
            List<ProcedureAnimalAid> validProcedureAnimalAids = new List<ProcedureAnimalAid>();

            foreach (ImpProcedureDto impProcedureDto in impProcedureDtos)
            {
                Vet vet = context.Vets.Where(v => v.Name == impProcedureDto.Vet).SingleOrDefault();
                Animal animal = context.Animals.Where(a => a.PassportSerialNumber == impProcedureDto.Animal).SingleOrDefault();

                if (!IsValid(impProcedureDto)
                    || !impProcedureDto.AnimalAids.Any(IsValid)
                    || vet == null
                    || animal == null
                    || !impProcedureDto.AnimalAids.All(aa => context.AnimalAids.Select(caa => caa.Name).Contains(aa.Name))
                    || impProcedureDto.AnimalAids.Select(aa => aa.Name).Count() != impProcedureDto.AnimalAids.Select(aa => aa.Name).Distinct().Count())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Procedure procedure = new Procedure()
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = DateTime.ParseExact(impProcedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                };
                foreach (string animalAidName in impProcedureDto.AnimalAids.Select(aa => aa.Name))
                {
                    AnimalAid animalAid = context.AnimalAids.Where(aa => aa.Name == animalAidName).SingleOrDefault();
                    ProcedureAnimalAid procedureAnimalAid = new ProcedureAnimalAid()
                    {
                        Procedure = procedure,
                        AnimalAid = animalAid
                    };

                    validProcedureAnimalAids.Add(procedureAnimalAid);
                }

                sb.AppendLine(ImportProcedureMessage);
            }

            context.ProceduresAnimalAids.AddRange(validProcedureAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
