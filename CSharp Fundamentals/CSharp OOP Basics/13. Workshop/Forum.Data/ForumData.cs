﻿using Forum.Models;
using System.Collections.Generic;

namespace Forum.Data
{
    public class ForumData
    {
        public List<User> Users { get; set;}

        public List<Category> Categories { get; set; }

        public List<Reply> Replies { get; set; }

        public List<Post> Posts { get; set; }

        public ForumData()
        {
            Users = DataMapper.LoadUsers();
            Categories = DataMapper.LoadCategories();
            Replies = DataMapper.LoadReplies();
            Posts = DataMapper.LoadPosts();
        }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users);
            DataMapper.SaveCategories(this.Categories);
            DataMapper.SaveReplies(this.Replies);
            DataMapper.SavePosts(this.Posts);
        }
    }
}
