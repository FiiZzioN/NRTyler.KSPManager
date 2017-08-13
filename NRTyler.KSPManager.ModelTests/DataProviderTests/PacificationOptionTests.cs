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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Services.Enums;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class PacificationOptionTests
	{
		[TestMethod]
		public void PacificationAssignment_Succeeded()
		{
			//Arrange
			var pacificationOption = new PacificationOption(PacificationType.GraveyardOrbit, 800);
			var expected = PacificationType.GraveyardOrbit;

			//Act
			var actual = pacificationOption.PacificationType;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DeltaVAssignment_Succeeded()
		{
			//Arrange
			var pacificationOption = new PacificationOption(PacificationType.Deorbit, 422);
			var expected = 422;

			//Act
			var actual = pacificationOption.RequiredDeltaV;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CatchNegativeDeltaVAssignment()
		{
			//Arrange
			var pacificationOption = new PacificationOption(PacificationType.Deorbit, -357);
			var expected = 0;

			//Act
			var actual = pacificationOption.RequiredDeltaV;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PacificationOption_ToString()
		{
			//Arrange
			var pacificationOption = new PacificationOption(PacificationType.GraveyardOrbit, 501);

			var oldString = $"Pacification Type: {StringEnum.GetStringValue(PacificationType.GraveyardOrbit)}@Required DeltaV: {501}";
			var expected = oldString.Replace("@", "\n");

			//Act
			var actual = pacificationOption.ToString();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}