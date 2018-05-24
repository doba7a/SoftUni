﻿using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Services
{
    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.ReplyIds)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);

                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            string[] allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        public static IEnumerable<Post> GetPostsByCategories(int categoryId)
        {
            ForumData forumData = new ForumData();

            ICollection<int> postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            string categoryName = postView.Category;

            Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                List<Category> categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;

                category = new Category(categoryId, categoryName, new List<int>());

                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyCategory)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postView, forumData);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(postView.Author);
            int authorId = author.Id;
            string content = string.Join("", postView.Content);

            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(postId);
            category.PostIds.Add(postId);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        internal static bool TrySaveReply(int postId, ReplyViewModel replyViewModel)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();

            List<Reply> replies = forumData.Replies;
            int replyId = replies.Any() ? replies.Last().Id + 1 : 1;

            Post post = forumData.Posts.First(p => p.Id == postId);
            User author = UserService.GetUser(replyViewModel.Author);
            int authorId = author.Id;

            string content = string.Join("", replyViewModel.Content);
            Reply reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();
            return true;
        }
    }
}
