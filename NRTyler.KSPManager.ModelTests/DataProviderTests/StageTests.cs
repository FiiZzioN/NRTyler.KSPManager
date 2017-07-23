// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class StageTests
	{
		[TestMethod]
		public void CalculateStageDeltaV()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = 450,
				DryMass = 1271,
				WetMass = 4159
			};

			var expected = 5231.47316929639;

			//Act
			var actual = stage.CalculateDeltaV();

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}

		[TestMethod]
		public void CalculateStageDeltaVISPNull()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = null,
				DryMass = 3494,
				WetMass = 9271
			};

			var expected = 0;

			//Act
			var actual = stage.CalculateDeltaV();

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}
	}
}