// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ConsoleAid
//
// Author           : Nicholas Tyler
// Created          : 07-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			var basegameSettings = new BaseGameSettings();
			basegameSettings.DayLengthMultiplier = 2;

			var lifesupportSettings = new LifeSupportSettings();

			var crewedVessel = new CrewedVehicle(basegameSettings, lifesupportSettings)
			{
				NumberOfCrew = 1
			};

			var lifeSupportSystem = crewedVessel.LifeSupportSystem;

			lifeSupportSystem.ProvisionsStorage.TotalFoodStored = 1.10;
			lifeSupportSystem.ProvisionsStorage.TotalWaterStored = 0.73;
			lifeSupportSystem.ProvisionsStorage.TotalOxygenStored = 111.04;
			lifeSupportSystem.ProvisionsStorage.TotalElectricityStored = 50;

			var food  = lifeSupportSystem.DaysWorthOfFood;
			var water = lifeSupportSystem.DaysWorthOfWater;
			var oxy   = lifeSupportSystem.DaysWorthOfOxygen;
			var elc   = lifeSupportSystem.DaysWorthOfElectricity;

			Write(food);
			Write(water);
			Write(oxy);
			Write(elc);
		}

		public static void Write(object value)
		{
			Console.WriteLine(value);
		}
	}
}
