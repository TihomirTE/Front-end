﻿namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCar = new Mock<Car>(); // return API
            
            // Diferrent Methods with MOQ

            //mockedCar.Setup(c => c.ShowInffo(It.Is<string>(s => s.StartsWith("B")))).Returns("Hello!!!");
            //mockedCar.Setup(c => c.ShowInffo(It.Is<string>(s => s.StartsWith("C")))).Throws(new System.ArgumentException());

            var resultCar = mockedCar.Object; // make it Object

            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());

            // Added Mokcs
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(x => x <= 0))).Returns(() => null);
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
