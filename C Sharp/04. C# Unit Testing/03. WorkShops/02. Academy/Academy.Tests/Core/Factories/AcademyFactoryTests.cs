namespace Academy.Tests.Core.Factories
{
    using System;

    using NUnit.Framework;
    using Moq;

    using Academy.Core.Factories;
    using Academy.Models.Contracts;
    using Academy.Models.Utils.LectureResources;

    [TestFixture]
    public class AcademyFactoryTests
    {
        [Test]
        public void CreateLectureResource_WhenTypeIsInvalid_ShouldThrowArgumentException()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => academyFactory.CreateLectureResource("", "Math", "www.math.bg"));
        }

        // Tests for checking correct instances
        [Test]
        public void CreateLectureResource_ShouldReturnCorrectVideoInstance()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            var mockedVideoLecture = new Mock<ILectureResource>();

            // Act
            var result = academyFactory.CreateLectureResource("video", "Star Wars", "www.starwars.com");

            // Assert
            Assert.IsInstanceOf(typeof(VideoResource), result);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectPresentationInstance()
        {
            var academyFactory = AcademyFactory.Instance;
            var mockedVideoLecture = new Mock<ILectureResource>();

            var result = academyFactory.CreateLectureResource("presentation", "Star Wars", "www.starwars.com");

            Assert.IsInstanceOf(typeof(PresentationResource), result);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectDemoInstance()
        {
            var academyFactory = AcademyFactory.Instance;
            var mockedVideoLecture = new Mock<ILectureResource>();

            var result = academyFactory.CreateLectureResource("demo", "Star Wars", "www.starwars.com");

            Assert.IsInstanceOf(typeof(DemoResource), result);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectHomeworkInstance()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            var mockedVideoLecture = new Mock<ILectureResource>();

            // Act
            var result = academyFactory.CreateLectureResource("homework", "Star Wars", "www.starwars.com");

            //Assert.IsInstanceOf(typeof(HomeworkResource), result);
            Assert.IsInstanceOf<HomeworkResource>(result);
        }
    }
}
