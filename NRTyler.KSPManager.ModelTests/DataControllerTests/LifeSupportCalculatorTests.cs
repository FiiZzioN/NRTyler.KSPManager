// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-25-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-25-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;
using NRTyler.KSPManager.Models.Interfaces;


namespace NRTyler.KSPManager.ModelTests.DataControllerTests
{
	[TestClass]
	public class LifeSupportCalculatorTests
	{
		[TestMethod]
		public void TestMethod()
		{
			//Arrange
			var vehicle = GenerateCrewedVehicle(2, 1);


			var expected = new List<double>()
			{

			};

			//Act
			//var actual = null;

			//Assert
			//Assert.AreEqual(expected, actual);
		}

		public ICrewable GenerateCrewedVehicle(int numberOfKerbals, double dayLengthModifier)
		{
			var lifeSettings                 = new LifeSupportSettings();
			var baseSettings                 = new BaseGameSettings();
			baseSettings.DayLengthMultiplier = dayLengthModifier;
			var vehicle                      = new CrewedVehicle(baseSettings, lifeSettings);
			vehicle.NumberOfCrew             = numberOfKerbals;


			return vehicle;
		}
	}
}
