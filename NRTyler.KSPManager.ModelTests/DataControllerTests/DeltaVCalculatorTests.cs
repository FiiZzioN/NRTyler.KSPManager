// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.ModelTests.DataControllerTests
{
	[TestClass]
	public class DeltaVCalculatorTests
	{
		[TestMethod]
		public void DeltaVCalculationStage()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = 293.0,
				DryMass = 100,
				WetMass = 160
			};

			var expected = 1350.48419958761;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(stage);

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}

		[TestMethod]
		public void DeltaVCalculationISPNull()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = 0,
				DryMass = 1271,
				WetMass = 4159
			};

			var expected = 0;

			//Act
			var actualStage = DeltaVCalculator.CalulateDeltaV(stage);
			var actualArguments = DeltaVCalculator.CalulateDeltaV(600, 4756, -5);

			//Assert
			Assert.AreEqual(expected, actualStage);
			Assert.AreEqual(expected, actualArguments);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeltaVCalculationStageNullException()
		{
			//Arrange
			Stage stage = null;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(stage);

			//Assert
			Assert.Fail($"{nameof(stage.SpecificImpulse)} was null.");
		}

		[TestMethod]
		public void DeltaVCalculationArguments()
		{
			//Arrange
			var expected = 2648.29183066939;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(6540, 14540, 338);

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}
	}
}