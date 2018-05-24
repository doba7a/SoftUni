namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using System.Linq;

    public class AddReplyController : IController
    {
        private enum Command
        {
            Write,
            Submit,
            Back
        }

        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private PostViewModel post;

        public bool Error { get; private set; }

        public int PostId { get; private set; }

        public PostViewModel PostView { get; set; }

        public TextArea TextArea { get; private set; }

        private ReplyViewModel Reply { get; set; }

        private static int centerLeft = Position.ConsoleCenter().Left;

        private static int centerTop = Position.ConsoleCenter().Top;

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    TextArea.Write();
                    Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;

                case Command.Submit:
                    bool validReply = PostService.TrySaveReply(this.PostView.PostId, this.Reply);

                    if (!validReply)
                    {
                        Error = true;
                        return MenuState.Rerender;
                    }

                    return MenuState.ReplyAdded;

                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;

            return new AddReplyView(PostView, Reply, TextArea, Error);
        }

        public void ResetReply()
        {
            int postTitleLines = this.PostView?.Content.Count + 1 ?? 1;
            this.TextArea = new TextArea(centerLeft - 18, centerTop + postTitleLines - 7, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);

            Reply = new ReplyViewModel();
            Error = false;
        }

        public void SetReplyToPost(int postId, string username)
        {
            PostId = postId;
            post = PostService.GetPostViewModel(postId);

            ResetReply();
            Reply.Author = username;
        }

        public void GetPostViewModel(int postId)
        {
            this.PostView = PostService.GetPostViewModel(postId);
            this.ResetReply();
        }
    }
}
