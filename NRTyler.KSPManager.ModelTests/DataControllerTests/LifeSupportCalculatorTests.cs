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
using NRTyler.KSPManager.Models.DataProviders.Settings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;
using NRTyler.KSPManager.Models.Interfaces;


namespace NRTyler.KSPManager.ModelTests.DataControllerTests
{
	[TestClass]
	public class LifeSupportCalculatorTests
	{


		public ICrewable GenerateCrewedVehicle(int numberOfKerbals, double dayLengthModifier)
		{
			var lifeSettings                 = new LifeSupportSettings();
			var baseSettings                 = new BaseGameSettings();
			var vehicle                      = new CrewedVehicle(baseSettings, lifeSettings);

		    baseSettings.DayLengthMultiplier = dayLengthModifier;
            vehicle.NumberOfCrew             = numberOfKerbals;

			return vehicle;
		}
	}
}
