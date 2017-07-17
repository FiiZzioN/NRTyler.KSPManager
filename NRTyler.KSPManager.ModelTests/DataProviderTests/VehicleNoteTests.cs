// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class VehicleNoteTests
	{
		[TestMethod]
		public void TitleNotNull()
		{
			//Arrange
			var vehicleNote = new VehicleNote();

			var expected = "Value Not Set";

			//Act
			var actual = vehicleNote.Title;
			Console.WriteLine(vehicleNote.ToString());

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TitleValid()
		{
			//Arrange
			var vehicleNote = new VehicleNote("Best Note");

			var expected = "Best Note";

			//Act
			var actual = vehicleNote.Title;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void NoteContentSet()
		{
			//Arrange
			var vehicleNote = new VehicleNote();
			vehicleNote.Content = "This is a note. Maybe note a great one, but it's mine.";

			var expected = "This is a note. Maybe note a great one, but it's mine.";

			//Act
			var actual = vehicleNote.Content;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}