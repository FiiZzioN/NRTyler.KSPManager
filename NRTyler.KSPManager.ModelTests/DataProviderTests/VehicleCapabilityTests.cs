// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class VehicleCapabilityTests
	{
		[TestMethod]
		public void DefaultConstructorInitialization()
		{
			//Arrange
			var vehicleCapability = new VehicleCapability();
			vehicleCapability.Trajectory.TrajectoryName = "My Constructor Test";
			vehicleCapability.PayloadRange.Lightest = 200;
			vehicleCapability.PayloadRange.Heaviest = 2400;

			var expectedTrajectory = "My Constructor Test";
			var expectedPayloadRange = new List<int> { 200, 2400 };

			//Act
			var actualTrajectory = vehicleCapability.Trajectory.TrajectoryName;
			var actualPayloadRange = new List<int> { vehicleCapability.PayloadRange.Lightest, vehicleCapability.PayloadRange.Heaviest };


			//Assert
			Assert.AreEqual(expectedTrajectory, actualTrajectory);
			CollectionAssert.AreEqual(expectedPayloadRange, actualPayloadRange);
		}

		[TestMethod]
		public void OverloadedConstructorInitialization()
		{
			//Arrange
			var vehicleCapability = new VehicleCapability("My Overloaded Constructor Test");

			vehicleCapability.PayloadRange.Lightest = 1000;
			vehicleCapability.PayloadRange.Heaviest = 3500;

			var expectedTrajectory = "My Overloaded Constructor Test";
			var expectedPayloadRange = new List<int> { 1000, 3500 };

			//Act
			var actualTrajectory = vehicleCapability.Trajectory.TrajectoryName;
			var actualPayloadRange = new List<int> { vehicleCapability.PayloadRange.Lightest, vehicleCapability.PayloadRange.Heaviest };


			//Assert
			Assert.AreEqual(expectedTrajectory, actualTrajectory);
			CollectionAssert.AreEqual(expectedPayloadRange, actualPayloadRange);
		}
	}
}