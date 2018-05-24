﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Forum.Data
{
    public class DataMapper
    {
        private const string DATA_PATH = "../data/";

        private const string CONFIG_Path = "config.ini";

        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_Path);
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            string[] contents = ReadLines(configPath);

            Dictionary<string, string> config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);

            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        } 
        
        public static List<Category> LoadCategories()
        {
            string[] lines = ReadLines(config["categories"]);

            List<Category> categories = new List<Category>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(';');

                int[] postIds = splitLine[2]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Category category = new Category(int.Parse(splitLine[0]), splitLine[1], postIds);

                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            const string categoryFormat = "{0};{1};{2}";

            List<string> lines = new List<string>();

            foreach (Category category in categories)
            {
                string line = string.Format(categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(",", category.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            string[] lines = ReadLines(config["users"]);

            List<User> users = new List<User>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(';');

                int[] postIds = splitLine[3]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                User user = new User(int.Parse(splitLine[0]), splitLine[1], splitLine[2], postIds);

                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            const string userFormat = "{0};{1};{2};{3}";

            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                string line = string.Format(userFormat,
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(",", user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            string[] lines = ReadLines(config["posts"]);

            List<Post> posts = new List<Post>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(';');

                int[] postIds = splitLine[5]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Post post = new Post(int.Parse(splitLine[0]), splitLine[1], splitLine[2], int.Parse(splitLine[3]), int.Parse(splitLine[4]), postIds);

                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            const string postFormat = "{0};{1};{2};{3};{4};{5}";

            List<string> lines = new List<string>();

            foreach (Post post in posts)
            {
                string line = string.Format(postFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(",", post.ReplyIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            string[] lines = ReadLines(config["replies"]);

            List<Reply> replies = new List<Reply>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                Reply reply = new Reply(int.Parse(splitLine[0]), splitLine[1], int.Parse(splitLine[2]), int.Parse(splitLine[3]));

                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            const string replyFormat = "{0};{1};{2};{3}";

            List<string> lines = new List<string>();

            foreach (Reply reply in replies)
            {
                string line = string.Format(replyFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthordId,
                    reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
