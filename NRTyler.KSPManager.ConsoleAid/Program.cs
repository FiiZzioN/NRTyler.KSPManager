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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NRTyler.CodeLibrary.Collections;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			var fileName = "datatest.xml";

			#region Old
			/*
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

			var obj = new LaunchVehicle("To Be Serialized");
			var note = new VehicleNote
			{
				Title = "This is a Note.",
				Content = "This is a simple note, but it's my note."
			};

			obj.DryMass = 30000;
			obj.WetMass = 200000;
			obj.Price = 130500;
			obj.VehicleType = VehicleType.LaunchVehicle;
			obj.StageInfo.Add(1, stageOne);
			obj.StageInfo.Add(2, stageTwo);
			obj.StageInfo.Add(3, stageThree);
			obj.VehicleNotes.Add(note);
			obj.CalculateDeltaV();
			*/
			#endregion

			var dictionary = new Dictionary<string, int>();

			dictionary.Add("One", 1);
			dictionary.Add("Two", 2);
			dictionary.Add("Three", 3);
			dictionary.Add("Four", 4);
			dictionary.Add("Five", 5);

			//var entryList = ToEntryList(dictionary);

			//var tett = Dict
			//TestSerialization(fileName, entryList);

			
			

			#region Ending

			//Write(null);
			//Write("Press any key to continue...");
			//Console.ReadKey();

			#endregion
		}

		/// <summary>
		/// Takes an <see cref="IDictionary"/>'s key and value, and then creates a new <see cref="DictionaryEntry{TKey, TValue}"/>
		/// object using those values. The DictionaryEntry is then added to an <see cref="IEnumerable{T}"/> collection. 
		/// </summary>
		/// 
		/// <typeparam name="TKey">The key's type.</typeparam>
		/// <typeparam name="TValue">The values's type.</typeparam>
		/// 
		/// <param name="dictionary"> 
		/// The <see cref="IDictionary"/> whose <see cref="KeyValuePair{TKey,TValue}"/>'s will be
		/// converted into a <see cref="DictionaryEntry{TKey, TValue}"/> enumerable collection.
		/// </param>
		/// 
		/// <returns>IEnumerable&lt;DictionaryEntry&lt;TKey, TValue&gt;&gt;.</returns>
		/// 
		/// <remarks>This is done for each <see cref="KeyValuePair{TKey,TValue}"/> in the <see cref="IDictionary{TKey,TValue}"/>.</remarks>
		private static IEnumerable<DictionaryEntry<TKey, TValue>> DictionaryToEntryList<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			var entryList = new List<DictionaryEntry<TKey, TValue>>();

			foreach (var i in dictionary)
			{
				var key   = i.Key;
				var value = i.Value;
				var entry = new DictionaryEntry<TKey, TValue>(key, value);

				entryList.Add(entry);
			}

			return entryList;
		}

		/// <summary>
		/// Takes an <see cref="IEnumerable{T}"/> collection of <see cref="DictionaryEntry{TKey, TValue}"/> objects. The object's key 
		/// and value are taken, and then those values are added to a <see cref="Dictionary{TKey,TValue}"/>. Once fully iterated 
		/// through the <see cref="IEnumerable{T}"/> collection, the <see cref="IDictionary{TKey,TValue}"/> is returned.
		/// </summary>
		/// 
		/// <typeparam name="TKey">The key's type.</typeparam>
		/// <typeparam name="TValue">The values's type.</typeparam>
		/// 
		/// <param name="list">
		/// The list whose <see cref="DictionaryEntry{TKey, TValue}"/>'s will be converted into an <see cref="IDictionary{TKey,TValue}"/>.
		/// </param>
		/// 
		/// <returns>IDictionary&lt;TKey, TValue&gt;.</returns>
		/// 
		/// <remarks>This is done for each <see cref="DictionaryEntry{TKey, TValue}"/> in the <see cref="IEnumerable{T}"/> collection.</remarks>
		private static IDictionary<TKey, TValue> EntryListToDictionary<TKey, TValue>(IEnumerable<DictionaryEntry<TKey, TValue>> list)
		{
			var dictionary = new Dictionary<TKey, TValue>();

			foreach (var i in list)
			{
				var key   = i.Key;
				var value = i.Value;

				dictionary.Add(key, value);
			}

			return dictionary;
		}


		/// <summary>
		/// Serializes the object to an XML file using the specified stream.
		/// </summary>
		/// <typeparam name="T">The type of object you're serializing.</typeparam>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		/// <exception cref="ArgumentNullException">obj - The object being serialized can not be null!</exception>
		private static void Serialize<T>(Stream stream, [NotNull] object obj)
		{
			// stream example: File.Open(fileName, FileMode.Create);

			if (obj == null) throw new ArgumentNullException(nameof(obj), "The object being serialized can not be null!");

			var formatter = new XmlSerializer(typeof(T));

			using (stream)
			{
				formatter.Serialize(stream, obj);
			}
		}

		/// <summary>
		/// Deserializes an XML file using the specified stream.
		/// </summary>
		/// <typeparam name="T">The type of object you're deserializing and returning.</typeparam>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		private static T Deserialize<T>(Stream stream)
		{
			// stream example: File.Open(fileName, FileMode.Open);

			var formatter = new XmlSerializer(typeof(T));

			using (stream)
			{
				return (T)formatter.Deserialize(stream);
			}
		}


		/*
		private static void TestSerialization(string fileName, object obj)
		{
			var stream = File.Open(fileName, FileMode.Create);
			//var formatter = new BinaryFormatter();
			var formatter = new XmlSerializer(typeof(LaunchVehicle));


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
			obj = new LaunchVehicle("Interim Vehicle");
			Write(obj.ToString());


			// Opens file "data.xml" and deserializes the object from it.
			stream    = File.Open(fileName, FileMode.Open);
			formatter = new XmlSerializer(typeof(LaunchVehicle));

			obj = (LaunchVehicle)formatter.Deserialize(stream);
			stream.Close();

			Write("");
			Write("---------------------");
			Write("After deserialization the object contains:");
			Write("---------------------");
			Write(obj.ToString());
			Write("");
		}
		*/

		private static void TestSerialization<TKey, TValue>(string fileName, List<DictionaryEntry<TKey, TValue>> obj)
		{
			var counter = 0;

			var stream = File.Open(fileName, FileMode.Create);
			//var formatter = new BinaryFormatter();
			var formatter = new XmlSerializer(typeof(List<DictionaryEntry<TKey, TValue>>));

			#region MyRegion


			Write("---------------------");
			Write("Before deserialization the object contains:");
			Write("---------------------");
			foreach (var i in obj)
			{
				Write($"  Key {counter}: {i.Key}");
				Write($"Value {counter}: {i.Value}");
				Write("");
				counter++;
			}
			counter = 0;

			// Opens a file and serializes the object into it in binary format.
			formatter.Serialize(stream, obj);
			stream.Close();

			// Empties object.
			Write("");
			Write("---------------------");
			Write("Interim value:");
			Write("---------------------");
			obj = new List<DictionaryEntry<TKey, TValue>>();
			foreach (var i in obj)
			{
				Write($"  Key {counter}: {i.Key}");
				Write($"Value {counter}: {i.Value}");
				Write("");
				counter++;
			}
			counter = 0;

			#endregion

			// Opens file "data.xml" and deserializes the object from it.
			stream = File.Open(fileName, FileMode.Open);
			formatter = new XmlSerializer(typeof(List<DictionaryEntry<TKey, TValue>>));

			obj = (List<DictionaryEntry<TKey, TValue>>)formatter.Deserialize(stream);
			stream.Close();

			Write("");
			Write("---------------------");
			Write("After deserialization the object contains:");
			Write("---------------------");
			foreach (var i in obj)
			{
				Write($"  Key {counter}: {i.Key}");
				Write($"Value {counter}: {i.Value}");
				Write("");
				counter++;
			}
			counter = 0;

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
