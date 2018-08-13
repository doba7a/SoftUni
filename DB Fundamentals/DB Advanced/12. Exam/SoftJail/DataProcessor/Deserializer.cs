namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImpDepartmentCellsDto[] impDepartmentCellsDtos = JsonConvert.DeserializeObject<ImpDepartmentCellsDto[]>(jsonString);
            List<Cell> validCells = new List<Cell>();

            foreach (ImpDepartmentCellsDto impDepartmentCellsDto in impDepartmentCellsDtos)
            {
                if (!IsValid(impDepartmentCellsDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool invalidCell = false;
                foreach (ImpCellDto impCellDto in impDepartmentCellsDto.Cells)
                {
                    if (!IsValid(impCellDto))
                    {
                        invalidCell = true;
                        break;
                    }
                }

                if (invalidCell)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department dept = new Department()
                {
                    Name = impDepartmentCellsDto.Name
                };

                foreach (ImpCellDto impCellDto in impDepartmentCellsDto.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = impCellDto.CellNumber,
                        HasWindow = impCellDto.HasWindow,
                        Department = dept
                    };

                    validCells.Add(cell);
                }

                sb.AppendLine($"Imported {dept.Name} with {impDepartmentCellsDto.Cells.Count()} cells");
            }

            context.Cells.AddRange(validCells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImpPrisonerMailsDto[] impPrisonersMailsDtos = JsonConvert.DeserializeObject<ImpPrisonerMailsDto[]>(jsonString);
            List<Mail> validMails = new List<Mail>();

            foreach (ImpPrisonerMailsDto impPrisonersMailsDto in impPrisonersMailsDtos)
            {
                if (!IsValid(impPrisonersMailsDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool invalidMail = false;
                foreach (ImpMailDto impMailDto in impPrisonersMailsDto.Mails)
                {
                    if (!IsValid(impMailDto))
                    {
                        invalidMail = true;
                        break;
                    }
                }

                if (invalidMail)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime IncarcerationDate = DateTime.ParseExact(impPrisonersMailsDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime? ReleaseDate = null;
                if (impPrisonersMailsDto.ReleaseDate != null)
                {
                    ReleaseDate = DateTime.ParseExact(impPrisonersMailsDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = impPrisonersMailsDto.FullName,
                    Nickname = impPrisonersMailsDto.Nickname,
                    Age = impPrisonersMailsDto.Age,
                    IncarcerationDate = IncarcerationDate,
                    ReleaseDate = ReleaseDate,
                    Bail = impPrisonersMailsDto.Bail,
                    CellId = impPrisonersMailsDto.CellId,
                };

                foreach (ImpMailDto impMailDto in impPrisonersMailsDto.Mails)
                {
                    Mail mail = new Mail()
                    {
                        Description = impMailDto.Description,
                        Sender = impMailDto.Sender,
                        Address = impMailDto.Address,
                        Prisoner = prisoner
                    };

                    validMails.Add(mail);
                }

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Mails.AddRange(validMails);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImpOfficerDto[]), new XmlRootAttribute("Officers"));
            ImpOfficerDto[] impOfficerDtos = (ImpOfficerDto[])serializer.Deserialize(new StringReader(xmlString));
            List<OfficerPrisoner> validOfficerPrisoners = new List<OfficerPrisoner>();

            foreach (ImpOfficerDto impOfficerDto in impOfficerDtos)
            {
                if (!IsValid(impOfficerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (Enum.TryParse<Position>(impOfficerDto.Position, out Position position) == false 
                    || Enum.TryParse<Weapon>(impOfficerDto.Weapon, out Weapon weapon) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = impOfficerDto.FullName,
                    Salary = impOfficerDto.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = impOfficerDto.DepartmentId
                };

                foreach (ImpPrisonerDto impPrisonerDto in impOfficerDto.OfficerPrisoners)
                {
                    Prisoner prisoner = context.Prisoners.Where(p => p.Id == impPrisonerDto.Id).SingleOrDefault();
                    OfficerPrisoner officerPrisoner = new OfficerPrisoner()
                    {
                        Officer = officer,
                        Prisoner = prisoner
                    };

                    validOfficerPrisoners.Add(officerPrisoner);
                }

                sb.AppendLine($"Imported {officer.FullName} ({impOfficerDto.OfficerPrisoners.Count()} prisoners)");
            }

            context.OfficersPrisoners.AddRange(validOfficerPrisoners);
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