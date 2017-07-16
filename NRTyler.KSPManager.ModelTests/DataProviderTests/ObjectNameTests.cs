// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-15-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-15-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class ObjectNameTests
	{
		[TestMethod]
		public void ObjectNameNullAssignment()
		{
			//Arrange
			var objectName = new ObjectName("  ");

			var expected = "Value Was Null";

			//Act
			var actual = objectName.Name;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ObjectNameAssignment()
		{
			//Arrange
			var nameToUse = "Atlas V";
			var objectName = new ObjectName(nameToUse);

			var expected = nameToUse;

			//Act
			var actual = objectName.Name;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ObjectNameGetName()
		{
			//Arrange
			var nameToUse = "Delta II";
			var objectName = new ObjectName(nameToUse);

			var expected = nameToUse;

			//Act
			var actual = objectName.GetName();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConvertToCultureTitleCase()
		{
			//Arrange
			var objectName = new ObjectName("falcon 9");

			var expected = CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Falcon 9".ToLower());
			
			//Act
			var actual = objectName.ToTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConvertToInvariantCultureTitleCase()
		{
			//Arrange
			var objectName = new ObjectName("spAce SHuttle discoveRy");

			var expected = CultureInfo.InvariantCulture.TextInfo.ToTitleCase("spAce SHuttle discoveRy".ToLower());

			//Act
			var actual = objectName.ToInvariantTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}