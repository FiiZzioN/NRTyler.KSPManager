// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ModelTests
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-13-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.ModelTests.DataControllerTests
{
	[TestClass]
	public class DeltaVCalculatorTests
	{
		[TestMethod]
		public void CalulateDeltaVOverloadOne()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = 293.0,
				DryMass         = 100,
				WetMass         = 160
			};

			var expected = 1350.48419958761;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(stage);

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}

		[TestMethod]
		public void CalulateDeltaVOverloadTwo()
		{
			//Arrange
			var expected = 2648.29183066939;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(6540, 14540, 338);

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}

		[TestMethod]
		public void CalulateDeltaVISPNull()
		{
			//Arrange
			var stage = new Stage()
			{
				SpecificImpulse = 0,
				DryMass         = 1271,
				WetMass         = 4159
			};

			var expected = 0;

			//Act
			var actualStage     = DeltaVCalculator.CalulateDeltaV(stage);
			var actualArguments = DeltaVCalculator.CalulateDeltaV(600, 4756, -5);

			//Assert
			Assert.AreEqual(expected, actualStage);
			Assert.AreEqual(expected, actualArguments);
		}

		[TestMethod]
		public void CalulateVehicleDeltaV()
		{
			//Arrange
			var vehicle = new Vehicle("DeltaV Testing");

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

			vehicle.StageInfo.Add(1, stageOne);
			vehicle.StageInfo.Add(2, stageTwo);
			vehicle.StageInfo.Add(3, stageThree);

			var expected = 7045.45946876031;
			//Act
			var actual = DeltaVCalculator.CalculateVehicleDeltaV(vehicle);

			//Assert
			Assert.AreEqual(expected, actual, 0.0000000001);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CalulateDeltaVStageNullException()
		{
			//Arrange
			Stage stage = null;

			//Act
			var actual = DeltaVCalculator.CalulateDeltaV(stage);

			//Assert
			Assert.Fail($"{nameof(stage.SpecificImpulse)} was null.");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CalulateVehicleDeltaVStageNullException()
		{
			//Arrange
			Vehicle vehicle = null;

			//Act
			var actual = DeltaVCalculator.CalculateVehicleDeltaV(vehicle);

			//Assert
			Assert.Fail($"{nameof(vehicle)} was null.");
		}
	}
}