// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 08-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests.VehicleTypes
{
	[TestClass]
	public class LaunchVehicleTests
	{

		[TestMethod]
		public void VehicleFairings()
		{
			// Arrange
			var vehicle = new LaunchVehicle();
			var fairing = new Fairing(6.3, 1.5, 220);

			vehicle.Fairings.Add("M", fairing);

			var expectedName     = "M";
			var expectedLength   = 6.3;
			var expectedDiameter = 1.5;
			var expectedMass     = 220;

			//Act
			var actualName     = vehicle.Fairings.Keys.ToList()[0];
			var actualLength   = vehicle.Fairings.Values.ToList()[0].Length;
			var actualDiameter = vehicle.Fairings.Values.ToList()[0].Diameter;
			var actualMass     = vehicle.Fairings.Values.ToList()[0].Mass;

			//Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedLength, actualLength);
			Assert.AreEqual(expectedDiameter, actualDiameter);
			Assert.AreEqual(expectedMass, actualMass);

		}

		[TestMethod]
		public void VehiclePacificationOption()
		{
			//Arrange
			var vehicle = new LaunchVehicle();
			var option  = new PacificationOption(PacificationType.GraveyardOrbit, 325);

			vehicle.PacificationOptions.Add("GraveYard", option);

			var expectedName = "GraveYard";
			var expectedType = PacificationType.GraveyardOrbit;
			var expectedDeltaV = 325;

			//Act
			var actualName   = vehicle.PacificationOptions.Keys  .ToList()[0];
			var actualType   = vehicle.PacificationOptions.Values.ToList()[0].PacificationType;
			var actualDeltaV = vehicle.PacificationOptions.Values.ToList()[0].RequiredDeltaV;

			//Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedType, actualType);
			Assert.AreEqual(expectedDeltaV, actualDeltaV);
		}

		[TestMethod]
		public void VehicleCapability()
		{
			//Arrange
			var range      = new PayloadRange(1250, 5000);
			var trajectory = new Trajectory(11475000, 150000, 22.0, 7400, "GTO");

			var vehicle           = new LaunchVehicle();
			var vehicleCapability = new VehicleCapability(range, trajectory);

			vehicle.Capability.Add(trajectory.Name, vehicleCapability);

			var expectedName       = "GTO";
			var expectedRange      = range;
			var expectedTrajectory = trajectory;

			//Act
			var actualName       = vehicle.Capability.Keys  .ToList()[0];
			var actualRange      = vehicle.Capability.Values.ToList()[0].PayloadRange;
			var actualTrajectory = vehicle.Capability.Values.ToList()[0].Trajectory;

			//Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedRange, actualRange);
			Assert.AreEqual(expectedTrajectory, actualTrajectory);
		}
	}
}