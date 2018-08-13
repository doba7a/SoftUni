using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Instagraph.Data;
using Instagraph.DataProcessor.Dto.Export;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var uncommentedPosts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(p => p.Id)
                .ToArray();

            string jsonPosts = JsonConvert.SerializeObject(uncommentedPosts, Newtonsoft.Json.Formatting.Indented);

            return jsonPosts;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var popularUsers = context.Users
                .Where(u => u.Posts.Any(p => p.Comments.Any(c => u.Followers.Any(f => f.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count()
                })
                .ToArray();

            string jsonUsers = JsonConvert.SerializeObject(popularUsers, Newtonsoft.Json.Formatting.Indented);

            return jsonUsers;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            ExportCommentsDto[] commentsOnPosts = context.Users
                .Select(u => new ExportCommentsDto
                {
                    Username = u.Username,
                    MostComments = u.Posts.Select(p => p.Comments.Count()).OrderByDescending(c => c).FirstOrDefault()
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCommentsDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), commentsOnPosts, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
