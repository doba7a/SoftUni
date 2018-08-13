using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using Instagraph.DataProcessor.Dto.Import;
using System.Xml.Serialization;
using System.IO;

namespace Instagraph.DataProcessor
{    
    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            Picture[] deserializedPictures = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            List<Picture> validPictures = new List<Picture>();
            HashSet<string> validPicturesPaths = new HashSet<string>();

            foreach (Picture picture in deserializedPictures)
            {
                if (!IsValid(picture) || validPicturesPaths.Contains(picture.Path))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validPicturesPaths.Add(picture.Path);

                validPictures.Add(picture);
                sb.AppendLine($"Successfully imported Picture {picture.Path}.");
            }

            context.AddRange(validPictures);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] deserializedUsers = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            List<User> validUsers = new List<User>();

            foreach (ImportUserDto userDto in deserializedUsers)
            {
                Picture userProfilePic = context.Pictures.SingleOrDefault(p => p.Path == userDto.ProfilePicture);

                if (!IsValid(userDto) || userProfilePic == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = Mapper.Map<User>(userDto);
                user.ProfilePicture = userProfilePic;
                user.ProfilePictureId = userProfilePic.Id;
                validUsers.Add(user);

                sb.AppendLine($"Successfully imported User {userDto.Username}.");
            }

            context.AddRange(validUsers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserFollowerDto[] importUserFollowerDtos = JsonConvert.DeserializeObject<ImportUserFollowerDto[]>(jsonString);
            List<UserFollower> validUserFollowers = new List<UserFollower>();

            foreach (ImportUserFollowerDto importUserFollowerDto in importUserFollowerDtos)
            {
                User user = context.Users.SingleOrDefault(u => u.Username == importUserFollowerDto.User);
                User follower = context.Users.SingleOrDefault(u => u.Username == importUserFollowerDto.Follower);

                if (!IsValid(importUserFollowerDto) || user == null || follower == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool alreadyFollowed = validUserFollowers.Any(uf => uf.User == user && uf.Follower == follower);
                if (alreadyFollowed)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                UserFollower userFollower = new UserFollower()
                {
                    UserId = user.Id,
                    User = user,
                    FollowerId = follower.Id,
                    Follower = follower
                };

                validUserFollowers.Add(userFollower);
                sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
            }

            context.AddRange(validUserFollowers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPostDto[]), new XmlRootAttribute("posts"));
            
            ImportPostDto[] deserializedPosts = (ImportPostDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Post> validPosts = new List<Post>();

            foreach (ImportPostDto importPostDto in deserializedPosts)
            {
                User user = context.Users.SingleOrDefault(u => u.Username == importPostDto.User);
                Picture picture = context.Pictures.SingleOrDefault(p => p.Path == importPostDto.Picture);

                if (!IsValid(importPostDto) || user == null || picture == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Post post = new Post()
                {
                    Caption = importPostDto.Caption,
                    UserId = user.Id,
                    User = user,
                    PictureId = picture.Id,
                    Picture = picture
                };

                validPosts.Add(post);
                sb.AppendLine($"Successfully imported Post {post.Caption}.");
            }

            context.Posts.AddRange(validPosts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCommentDto[]), new XmlRootAttribute("comments"));

            ImportCommentDto[] deserializedComments = (ImportCommentDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Comment> validComments = new List<Comment>();

            foreach (ImportCommentDto importCommentDto in deserializedComments)
            {
                User user = context.Users.SingleOrDefault(u => u.Username == importCommentDto.User);

                if (importCommentDto.PostId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int postId = int.Parse(importCommentDto.PostId.Id);
                Post post = context.Posts.Find(postId);

                if (!IsValid(importCommentDto) || user == null || post == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Comment comment = new Comment()
                {
                    Content = importCommentDto.Content,
                    UserId = user.Id,
                    User = user,
                    PostId = post.Id,
                    Post = post,
                };

                validComments.Add(comment);
                sb.AppendLine($"Successfully imported Comment {comment.Content}.");
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
