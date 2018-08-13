namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            ExpPrisonerByCellDto[] jsonPrisonersByCell = new ExpPrisonerByCellDto[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                ExpPrisonerByCellDto prisoner = context.Prisoners
                    .Where(p => p.Id == ids[i])
                    .Select(p => new ExpPrisonerByCellDto
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        CellNumber = p.Cell.CellNumber,
                        Officers = p.PrisonerOfficers.Select(po => new ExpOfficerByCellDto
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                        TotalOfficerSalary = p.PrisonerOfficers.DefaultIfEmpty().Sum(po => po.Officer.Salary)
                    })
                    .SingleOrDefault();

                jsonPrisonersByCell[i] = prisoner;
            }

            jsonPrisonersByCell = jsonPrisonersByCell
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string jsonPosts = JsonConvert.SerializeObject(jsonPrisonersByCell, Newtonsoft.Json.Formatting.Indented);

            return jsonPosts;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisoners = prisonersNames.Split(',');

            ExpPrisonerInboxDto[] expPrisonerInboxDtos = new ExpPrisonerInboxDto[prisoners.Length];

            for (int i = 0; i < prisoners.Length; i++)
            {
                ExpPrisonerInboxDto prisoner = context.Prisoners
                    .Where(p => p.FullName == prisoners[i])
                    .Select(p => new ExpPrisonerInboxDto
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                        EncryptedMessages = p.Mails.Select(m => new ExpInboxDto
                        {
                            Description = Reverse(m.Description)
                        })
                        .ToArray()
                    })
                    .SingleOrDefault();

                expPrisonerInboxDtos[i] = prisoner;
            }

            expPrisonerInboxDtos = expPrisonerInboxDtos
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExpPrisonerInboxDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), expPrisonerInboxDtos, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}