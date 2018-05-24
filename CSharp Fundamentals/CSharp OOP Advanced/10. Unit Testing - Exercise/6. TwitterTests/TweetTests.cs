using Moq;
using NUnit.Framework;

[TestFixture]
public class TweetTests
{
    [Test]
    public void ReceiveMessageShouldInvokeItsClientToWriteTheMessageTest()
    {
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);

        tweet.ReceiveMessage("Test");

        client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to write the message");
    }

    [Test]
    public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServerTest()
    {
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);

        tweet.ReceiveMessage("Test");

        client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to send the message to the server");
    }
}
