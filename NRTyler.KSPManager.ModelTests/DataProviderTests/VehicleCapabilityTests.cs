// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class VehicleCapabilityTests
	{
		[TestMethod]
		public void VehicleCapabilityConstructor()
		{
			//Arrange
			var payloadRange      = new PayloadRange(250, 800);
			var trajectory        = new Trajectory(120000, 110000, 33.2, "LEO");
			var vehicleCapability = new VehicleCapability(payloadRange, trajectory);

			var expected = new List<object> { payloadRange, trajectory};

			//Act
			var actual = new List<object> { vehicleCapability.PayloadRange, vehicleCapability.Trajectory };

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}