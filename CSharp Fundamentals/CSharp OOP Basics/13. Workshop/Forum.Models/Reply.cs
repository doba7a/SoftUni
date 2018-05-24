namespace Forum.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthordId { get; set; }

        public int PostId { get; set; }

        public Reply(int id, string content, int authorId, int postId)
        {
            Id = id;
            Content = content;
            AuthordId = authorId;
            PostId = postId;
        }
    }
}
