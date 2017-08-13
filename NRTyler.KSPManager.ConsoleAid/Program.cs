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
using System.ComponentModel;
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			var stageOne = new Stage()
			{
				DryMass = 250,
				WetMass = 650,
				SpecificImpulse = 302
			};

			var stageTwo = new Stage()
			{
				DryMass = 500,
				WetMass = 1200,
				SpecificImpulse = 332
			};

			var stageThree = new Stage()
			{
				DryMass = 2200,
				WetMass = 7000,
				SpecificImpulse = 348
			};

			var stageOneDeltaV   = DeltaVCalculator.CalulateDeltaV(stageOne);
			var stageTwoDeltaV   = DeltaVCalculator.CalulateDeltaV(stageTwo);
			var stageThreeDeltaV = DeltaVCalculator.CalulateDeltaV(stageThree);


			Write(Math.Round(stageOneDeltaV, 2));
			Write(null);
			Write(Math.Round(stageTwoDeltaV, 2));
			Write(null);
			Write(Math.Round(stageThreeDeltaV, 2));
			Write("----------------------------------------");



			var vehicle = new Vehicle("DeltaV Testing");

			vehicle.StageInfo.Add(1, stageOne);
			vehicle.StageInfo.Add(2, stageTwo);
			vehicle.StageInfo.Add(3, stageThree);

			Write(null);
			Write(Math.Round(DeltaVCalculator.CalculateVehicleDeltaV(vehicle), 2));






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
