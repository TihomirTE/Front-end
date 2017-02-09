namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Cars.Tests.JustMock.Mocks;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
             : this(new MoqCarsRepository())
        //: this(new JustMockCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))] // version 1
        public void AddingCar_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            //Version 1
            //var model = (Car)this.GetModel(() => this.controller.Add(null));
            
            // Arrange
            var car = new Car();
            // Act
            car = null;
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() =>this.controller.Add(car));
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            //var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.ThrowsException<ArgumentNullException>(() => this.controller.Add(car));
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            //var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.ThrowsException<ArgumentNullException>(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCar_ShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // Homeworks Tests
        [TestMethod]
        public void SearchingCar_ShouldReturnRightView()
        {
            var str = "anystring";

            var result = (ICollection<Car>)this.GetModel(() => this.controller.Search(str));
            // CarRepositoryMock has 2 "BMW" => result.Count = 2
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))] // Assert MSTest
        public void Details_ShouldReturnArgumentNullException_WhenIncorrectIDIsPassed()
        {
            // Arrange
            int id = -1;

            // Act NUnit
            //var car = (Car)this.GetModel(() => this.controller.Details(id));

            // Assert & Act -> MSTest version 2
            Assert.ThrowsException<ArgumentNullException>(() => this.controller.Details(id));
            
            // Assert NUnit
            //Assert.Throws<ArgumentNullException>((Car)this.GetModel(() => this.controller.Details(ca));
            
         }

        [TestMethod]
        public void Sort_WithParameterMake_ShouldReturnSortedByMake()
        {
            var sort = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(1, sort[0].Id);
            Assert.AreEqual(2, sort[1].Id);
            Assert.AreEqual(3, sort[2].Id);
            Assert.AreEqual(4, sort[3].Id);
        }

        [TestMethod]
        public void Sort_WithParameterYear_ShouldReturnSortedByYear()
        {
            var sort = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(1, sort[0].Id);
            Assert.AreEqual(3, sort[1].Id);
            Assert.AreEqual(2, sort[2].Id);
            Assert.AreEqual(4, sort[3].Id);
        }

        [TestMethod]
        public void Sort_WithInvalidParameter_ShouldReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => this.controller.Sort("lada"));
        }


        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
