// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 08-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class VehicleEntryTests
	{
		[TestMethod]
		public void ConstructorTwo()
		{
			// Arrange
			var vehicle = new Vehicle
			{
				Name        = "Test Vehicle",
				Price       = 143500,
				VehicleType = VehicleType.LaunchVehicle
			};

			var entry = new VehicleEntry(vehicle);

			var expectedName  = "Test Vehicle";
			var expectedPrice = 143500;
			var expectedType  = VehicleType.LaunchVehicle;

			// Act
			var actualName  = vehicle.Name;
			var actualPrice = vehicle.Price;
			var actualType  = vehicle.VehicleType;

			// Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedPrice, actualPrice);
			Assert.AreEqual(expectedType, actualType);
		}

		[TestMethod]
		public void AddToEntry()
		{
			// Arrange
			var vehicle = new Vehicle
			{
				Name        = "Another Test",
				Price       = 50000,
				VehicleType = VehicleType.Probe
			};

			var entry = new VehicleEntry();
			    entry.AddToEntry(vehicle);

			var expectedName  = "Another Test";
			var expectedPrice = 50000;
			var expectedType  = VehicleType.Probe;

			// Act
			var actualName  = vehicle.Name;
			var actualPrice = vehicle.Price;
			var actualType  = vehicle.VehicleType;

			// Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedPrice, actualPrice);
			Assert.AreEqual(expectedType, actualType);
		}

		[TestMethod]
		public void InvalidPrice()
		{
			// Arrange
			var vehicle = new Vehicle
			{
				Name        = "PriceTest",
				Price       = -20,
				VehicleType = VehicleType.Satellite
			};

			var entry    = new VehicleEntry(vehicle);
			var expected = 0;

			// Act
			var actual = entry.Price;

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}