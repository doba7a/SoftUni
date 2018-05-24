using Moq;
using NUnit.Framework;

[TestFixture]
public class MicrowaveOvenTests
{
    private const string Message = "Test";

    [Test]
    public void SendTweetToServerShouldSendTheMessageToItsServerTest()
    {
        Mock<IWriter> writer = new Mock<IWriter>();
        Mock<ITweetRepository> tweetRepo = new Mock<ITweetRepository>();
        tweetRepo.Setup(tr => tr.SaveTweet(It.IsAny<string>()));
        MicrowaveOven microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);

        microwaveOven.SendTweetToServer(Message);

        tweetRepo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == Message)), Times.Once, "Message is not sent to the server");
    }

    [Test]
    public void WriteTweetShouldCallItsWriterWithTheTweetsMessageTest()
    {
        Mock<IWriter> writer = new Mock<IWriter>();
        writer.Setup(w => w.WriteLine(It.IsAny<string>()));
        Mock<ITweetRepository> tweetRepo = new Mock<ITweetRepository>();
        MicrowaveOven microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);

        microwaveOven.WriteTweet(Message);

        writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)), $"Tweet is not given to the {typeof(MicrowaveOven)}'s writer");
    }
}
