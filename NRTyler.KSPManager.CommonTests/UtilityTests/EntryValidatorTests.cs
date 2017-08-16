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
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Common.Utilities;

namespace NRTyler.KSPManager.CommonTests.UtilityTests
{
	[TestClass]
	public class EntryValidatorTests
	{
		[TestMethod]
		public void EntryValidatorInvalidInput()
		{
			//Arrange
			var smallerNumber = 487;
			var biggerNumber = 43;

			EntryValidator.EnsureProperAssignment(ref smallerNumber, ref biggerNumber);

			Console.WriteLine($"SmallerNumber: {smallerNumber}");
			Console.WriteLine($"BiggerNumber: {biggerNumber}");

			var expected = new List<int>{ 43, 487};

			//Act
			var actual = new List<int> { smallerNumber, biggerNumber };

			foreach (var n in actual)
			{
				Console.WriteLine(n);
			}

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void EntryValidatorValidInput()
		{
			//Arrange
			var smallerNumber = 29685;
			var biggerNumber = 93715;

			EntryValidator.EnsureProperAssignment(ref smallerNumber, ref biggerNumber);

			Console.WriteLine($"SmallerNumber: {smallerNumber}");
			Console.WriteLine($"BiggerNumber: {biggerNumber}");

			var expected = new List<int> { 29685, 93715 };

			//Act
			var actual = new List<int> { smallerNumber, biggerNumber };

			foreach (var n in actual)
			{
				Console.WriteLine(n);
			}

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}