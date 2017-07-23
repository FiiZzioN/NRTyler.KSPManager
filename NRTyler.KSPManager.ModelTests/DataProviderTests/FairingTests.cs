// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-20-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class FairingTests
	{
		[TestMethod]
		public void FairingInstantiation()
		{
			//Arrange instantiation
			var fairing = new Fairing(14, 3.25m);

			var expected = new List<decimal?> { 14, 3.25m};

			//Act
			var actual = new List<decimal?> { fairing.Length, fairing.Diameter };

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FairingInvalidLength()
		{
			//Arrange instantiation
			var fairing = new Fairing(-1, 2m);

			var expected = new List<decimal?> { null, 2m };

			//Act
			var actual = new List<decimal?> { fairing.Length, fairing.Diameter };

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FairingInvalidDiameter()
		{
			//Arrange instantiation
			var fairing = new Fairing(10, -1m);

			var expected = new List<decimal?> { 10, null};

			//Act
			var actual = new List<decimal?> { fairing.Length, fairing.Diameter };

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FairingNullEntry()
		{
			//Arrange instantiation
			var fairing = new Fairing(null, 1.5m);

			var expected = new List<decimal?> { null, 1.5m };

			//Act
			var actual = new List<decimal?> { fairing.Length, fairing.Diameter };

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}