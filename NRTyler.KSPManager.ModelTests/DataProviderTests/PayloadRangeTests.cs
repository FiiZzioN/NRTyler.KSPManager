// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-14-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class PayloadRangeTests
	{
		[TestMethod]
		public void RangeAssignment_Succeeded()
		{
			//Arrange
			var range = new PayloadRange(500, 5000);
			var rangeList = new List<int>
			{
				range.Lightest,
				range.Heaviest
			};

			var expected = new List<int> { 500, 5000 };

			//Act
			var actual = rangeList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParameterGoof_Caught()
		{
			//Arrange
			var range = new PayloadRange(2000, 200);
			var rangeList = new List<int>
			{
				range.Lightest,
				range.Heaviest
			};

			var expected = new List<int> { 200, 2000 };

			//Act
			var actual = rangeList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void NegativeParameter_Caught()
		{
			//Arrange
			var range = new PayloadRange(-50, 350);
			var rangeList = new List<int>
			{
				range.Lightest,
				range.Heaviest
			};

			var expected = new List<int> { 0, 350 };

			//Act
			var actual = rangeList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PayloadRange_ToString()
		{
			//Arrange
			var range = new PayloadRange(400, 1000);
			var oldString = $"Lightest: {400}@Heaviest: {1000}";

			var expected = oldString.Replace("@", "\n");

			//Act
			var actual = range.ToString();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}