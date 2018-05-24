namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void SetControllerDidNotPerformTest()
        {
            IStage stage = new Stage();
            ISet set = new Long("set1");
            stage.AddSet(set);

            ISetController sc = new SetController(stage);

            Assert.That(sc.PerformSets, Is.EqualTo("1. set1:\r\n-- Did not perform"));
        }

        [Test]
        public void SetControllerSetSuccessfulTest()
        {
            ISong song = new Song("song1", new TimeSpan(0, 3, 10));
            ISong song2 = new Song("song2", new TimeSpan(0, 4, 10));

            IPerformer performer = new Performer("pesho", 30);
            IInstrument guitar = new Guitar();
            performer.AddInstrument(guitar);

            ISet set = new Long("set1");
            set.AddPerformer(performer);
            set.AddSong(song);
            set.AddSong(song2);

            IStage stage = new Stage();
            stage.AddSet(set);

            ISetController sc = new SetController(stage);

            Assert.That(sc.PerformSets, Is.EqualTo("1. set1:\r\n-- 1. song1 (03:10)\r\n-- 2. song2 (04:10)\r\n-- Set Successful"));
        }

        [Test]
        public void SetControllerDidNotPerformWithBrokenInstrumentsTest()
        {
            ISong song = new Song("song1", new TimeSpan(0, 3, 10));

            IPerformer performer = new Performer("pesho", 30);
            IInstrument guitar = new Guitar();
            performer.AddInstrument(guitar);

            ISet set = new Long("set1");
            set.AddPerformer(performer);
            set.AddSong(song);

            IStage stage = new Stage();
            stage.AddSet(set);

            ISetController sc = new SetController(stage);

            sc.PerformSets();
            sc.PerformSets();

            Assert.That(sc.PerformSets, Is.EqualTo("1. set1:\r\n-- Did not perform"));
        }

        [Test]
        public void SetControllerEmptyTest()
        {
            IStage stage = new Stage();

            ISetController sc = new SetController(stage);

            Assert.That(sc.PerformSets, Is.EqualTo(""));
        }
    }
}
