// ***********************************************************************
// Assembly         : NRTyler.KSPManager.CommonTests
//
// Author           : Nicholas Tyler
// Created          : 08-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Common.ExtensionMethods;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.CommonTests.ExtensionMethodTests
{
	[TestClass]
	public class StringExtensionTests
	{
		[TestMethod]
		public void ConvertToCultureTitleCase()
		{
			//Arrange
			var title = "thiS tiTle is All MesSed uP";

			var expected = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title);

			//Act
			var actual = title.ToTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConvertToInvariantCultureTitleCase()
		{
			//Arrange
			var title = "thiS tiTle is All MesSed uP";

			var expected = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(title);

			//Act
			var actual = title.ToInvariantTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsureValidTitle()
		{
			//Arrange
			var trajectory = new Trajectory("Billy");

			var expected = "Billy";

			//Act
			var actual = trajectory.Name;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsureAgainstInvalidTitle()
		{
			//Arrange
			var trajectory = new Trajectory("Bob");

			trajectory.Name = String.Empty;

			var expected = "Invalid Title";

			//Act
			var actual = trajectory.Name;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}