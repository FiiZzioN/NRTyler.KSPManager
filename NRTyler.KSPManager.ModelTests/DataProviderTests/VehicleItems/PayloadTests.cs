// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 08-12-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-12-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests.VehicleItems
{
	[TestClass]
	public class PayloadTests
	{
		[TestMethod]
		public void ConstructorOne()
		{
			//Arrange
			var vehicle  = new Vehicle("Test Payload");
			var payload  = new Payload(vehicle);
			var expected = payload.Vehicle;

			//Act
			var actual = vehicle;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}