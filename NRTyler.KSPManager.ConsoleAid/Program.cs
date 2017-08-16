// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ConsoleAid
//
// Author           : Nicholas Tyler
// Created          : 07-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-15-2017
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
			var vehicle = new Vehicle("DeltaV Testing");

			#region Stages

			var stageOne = new Stage()
			{
				DryMass = 1010,
				WetMass = 4010,
				SpecificImpulse = 340
			};

			var stageTwo = new Stage()
			{
				DryMass = 2050,
				WetMass = 8050,
				SpecificImpulse = 310
			};

			#endregion

			vehicle.StageInfo.Add(1, stageOne);
			vehicle.StageInfo.Add(2, stageTwo);


			Write(DeltaVCalculator.CalculateVehicleDeltaV(vehicle));


			#region Ending

			//Write(null);
			//Write("Press any key to continue...");
			//Console.ReadKey();

			#endregion
		}

		private static Tuple<double, double, double, double> TestLifeSupport(double dayLengthModifier)
		{
			var basegameSettings = new BaseGameSettings();
			basegameSettings.DayLengthMultiplier = dayLengthModifier;

			var lifesupportSettings = new LifeSupportSettings();

			var crewedVessel = new CrewedVehicle(basegameSettings, lifesupportSettings)
			{
				NumberOfCrew = 1
			};

			var lifeSupportSystem = crewedVessel.LifeSupportSystem;

			lifeSupportSystem.ProvisionsStorage.TotalFoodStored        = 1.10;
			lifeSupportSystem.ProvisionsStorage.TotalWaterStored       = 0.73;
			lifeSupportSystem.ProvisionsStorage.TotalOxygenStored      = 111.04;
			lifeSupportSystem.ProvisionsStorage.TotalElectricityStored = 50;

			var food  = lifeSupportSystem.DaysWorthOfFood;
			var water = lifeSupportSystem.DaysWorthOfWater;
			var oxy   = lifeSupportSystem.DaysWorthOfOxygen;
			var elec  = lifeSupportSystem.DaysWorthOfElectricity;

			var eatenPerSecond = crewedVessel.LifeSupportSettings.FoodPerDay / 21600;
			var foodTotalTimeSeconds = lifeSupportSystem.ProvisionsStorage.TotalFoodStored / eatenPerSecond;

			Write(foodTotalTimeSeconds);

			Write(DeltaVCalculator.CalulateDeltaV(10470, 19357, 312));

			return new Tuple<double, double, double, double>(food, water, oxy, elec);
		}

		public static void Write(object value)
		{
			Console.WriteLine(value);
		}
	}
}
