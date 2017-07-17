// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ServiceTests
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.ServiceTests.UtilityTests
{
	[TestClass]
	public class StringAssistantTests
	{
		[TestMethod]
		public void ConvertToCultureTitleCase()
		{
			//Arrange
			var title = "thiS tiTle is All MesSed uP";

			var expected = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title);

			//Act
			var actual = StringAssistant.ToTitleCase(title);

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
			var actual = StringAssistant.ToInvariantTitleCase(title);

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}