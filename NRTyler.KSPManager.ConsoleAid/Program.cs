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
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using NRTyler.KSPManager.Common.Enums;
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
			#region Stages

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

			#endregion

			var fileName = "datatest.xml";
			var obj      = new Vehicle("To Be Serialized");
			var note = new VehicleNote()
			{
				Title   = "This is a Note.",
				Content = "This is a simple note, but it's my note."
			};

			obj.DryMass     = 30000;
			obj.WetMass     = 200000;
			obj.Price       = 130500;
			obj.VehicleType = VehicleType.LaunchVehicle;
			obj.StageInfo   .Add(1, stageOne);
			obj.StageInfo   .Add(2, stageTwo);
			obj.StageInfo   .Add(3, stageThree);
			obj.VehicleNotes.Add(note);
			obj.CalculateDeltaV();

			TestSerialization(fileName, obj);

			#region Ending

			//Write(null);
			//Write("Press any key to continue...");
			//Console.ReadKey();

			#endregion
		}


		private static void TestSerialization(string fileName, object obj)
		{
			var stream = File.Open(fileName, FileMode.Create);
			//var formatter = new BinaryFormatter();
			var formatter = new XmlSerializer(typeof(Vehicle));


			Write("---------------------");
			Write("Before deserialization the object contains:");
			Write("---------------------");
			Write(obj.ToString());

			// Opens a file and serializes the object into it in binary format.
			formatter.Serialize(stream, obj);
			stream.Close();

			// Empties object.
			Write("");
			Write("---------------------");
			Write("Interim value:");
			Write("---------------------");
			obj = new Vehicle("Interim Vehicle");
			Write(obj.ToString());


			// Opens file "data.xml" and deserializes the object from it.
			stream    = File.Open(fileName, FileMode.Open);
			formatter = new XmlSerializer(typeof(Vehicle));

			obj = (Vehicle)formatter.Deserialize(stream);
			stream.Close();

			Write("");
			Write("---------------------");
			Write("After deserialization the object contains:");
			Write("---------------------");
			Write(obj.ToString());
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
