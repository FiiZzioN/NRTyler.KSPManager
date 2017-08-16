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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
			TestSerialization();

			#region Ending

			//Write(null);
			//Write("Press any key to continue...");
			//Console.ReadKey();

			#endregion
		}


		private static void TestSerialization()
		{
			var fileName = "datatest.txt";

			var fairing = new Fairing(1.25, 4.2, 50);
			var stream = File.Open(fileName, FileMode.Create);
			var formatter = new BinaryFormatter();


			Write("---------------------");
			Write("Before deserialization the object contains:");
			Write("---------------------");
			Write(fairing.ToString());

			// Opens a file and serializes the object into it in binary format.
			formatter.Serialize(stream, fairing);
			stream.Close();


			// Empties fairing.
			Write("");
			Write("---------------------");
			Write("Interim value:");
			Write("---------------------");
			fairing = new Fairing(0, 0, 0);
			Write(fairing.ToString());


			// Opens file "data.xml" and deserializes the object from it.
			stream = File.Open(fileName, FileMode.Open);
			formatter = new BinaryFormatter();

			fairing = (Fairing)formatter.Deserialize(stream);
			stream.Close();

			Write("");
			Write("---------------------");
			Write("After deserialization the object contains:");
			Write("---------------------");
			Write(fairing.ToString());
			Write("");
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
