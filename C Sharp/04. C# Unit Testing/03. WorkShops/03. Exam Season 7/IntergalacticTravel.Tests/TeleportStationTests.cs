using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenNewTeleportStationIsCreated_ShouldSetUpAllFields()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();

            var expectedOwner = owner.Object;
            var expectedGalacticMap = galacticMap.Object;
            var expectedLocation = location.Object;

            // Act
            var teleportStation = new ExtendedTeleportStation(expectedOwner, expectedGalacticMap, expectedLocation);
            var actualOwner = teleportStation.Owner;
            var actualGalacticMap = teleportStation.GalacticMap;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreSame(expectedOwner, actualOwner);
            Assert.AreSame(expectedGalacticMap, actualGalacticMap);
            Assert.AreSame(expectedLocation, actualLocation);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionWithMessage()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var teleportStation = new TeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var mockedTargetLocation = new Mock<ILocation>();

            // Act
            var result = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, mockedTargetLocation.Object));
            // Assert
            StringAssert.Contains("unitToTeleport", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenDestinationIsNull_ShouldThrowArgumentNullExceptionWithMessage()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new TeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();

            // Act
            var result = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, null));
            // Assert
            StringAssert.Contains("destination", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenUnitUseTeleportStationFromADistantLocation_ShouldThrowTeleportOutOfRangeExceptionWithMessage()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();


            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.Setup(x => x.Name).Returns("Earth");
            mockedPlanet.Setup(x => x.Galaxy.Name).Returns("MilkWay");
            mockedLocation.Setup(x => x.Planet).Returns(mockedPlanet.Object);

            var teleportStation = new TeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var mockedCurrentPlanet = new Mock<IPlanet>();
            mockedCurrentPlanet.Setup(x => x.Name).Returns("Mars");
            mockedCurrentPlanet.Setup(x => x.Galaxy.Name).Returns("MilkWay");

            var mockedCurrentLocation = new Mock<ILocation>();
            mockedCurrentLocation.Setup(x => x.Planet).Returns(mockedCurrentPlanet.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(mockedCurrentLocation.Object);

            var mockedtargetLocation = new Mock<ILocation>();

            // Act
            var result = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedtargetLocation.Object));

            // Assert
            StringAssert.Contains("unitToTeleport.CurrentLocation", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenTryingToTeleportUnitToATakenLocation_ShouldThrowInvalidTeleportationLocationException()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";
            var latitude = 27d;
            var longtitude = 44d;

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(200);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(100);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(50);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new TeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            var result = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));

            // Arrange
            StringAssert.Contains("units will overlap", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenAGalaxyIsNotFound_ShouldThrowLocationNotFoundException()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(200);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(100);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(50);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");

            var planetaryUnitMock = new Mock<IUnit>();

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new TeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            var result = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));

            // Arrange
            StringAssert.Contains("Galaxy", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenAPlanetIsNotFound_ShouldThrowLocationNotFoundException()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(200);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(100);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(50);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns("Earth");
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new TeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            var result = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));

            // Arrange
            StringAssert.Contains("Planet", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenThereIsUnsufficientResourcesToTeleport_ShouldThrowInsufficientResourcesException()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";
            var latitude = 27d;
            var longtitude = 44d;

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(200);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(50);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(20);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 10d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 10d);

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new TeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);


            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            locationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            // Act
            var result = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));

            // Arrange
            StringAssert.Contains("FREE LUNCH", result.Message);
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPassed_ShouldRequireAPayment()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";
            var latitude = 27d;
            var longtitude = 44d;

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(2);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(5);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(2);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 10d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 10d);

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var currentUnitLocationPlanetaryUnitList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            locationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.Verify(x => x.Pay(pathMock.Object.Cost), Times.Once());
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPassed_ShouldObtainAPayment()
        {
            // Arrange
            var planetName = "Mars";
            var galaxyName = "MilkyWay";
            var latitude = 27d;
            var longtitude = 44d;

            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(2);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(5);
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(2);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 10d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 10d);

            var planetaryUnitList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitList);

            var currentUnitLocationPlanetaryUnitList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(ownerMock.Object, teleportStationMapMock, locationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            locationMock.Setup(x => x.Planet.Name).Returns(planetName);
            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            var expectedBronzeCoins = initialTeleportStationResources.BronzeCoins + pathMock.Object.Cost.BronzeCoins;
            var expectedSilverCoins = initialTeleportStationResources.SilverCoins + pathMock.Object.Cost.SilverCoins;
            var expectedGoldCoins = initialTeleportStationResources.GoldCoins + pathMock.Object.Cost.GoldCoins;

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);
            var actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            var actualSilverCoins = teleportStation.Resources.SilverCoins;
            var actualGoldcoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldcoins);
        }




    }
}
