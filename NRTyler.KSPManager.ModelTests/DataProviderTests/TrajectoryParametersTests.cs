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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.ModelTests.DataProviderTests
{
	[TestClass]
	public class TrajectoryParametersTests
	{
		[TestMethod]
		public void RangeAssignment_Succeeded()
		{
			//Arrange
			var parameters = new TrajectoryParameters();

			parameters.Apoapsis = 200000;
			parameters.Periapsis = 120000;
			parameters.Inclination = -32.22;
			parameters.RequiredDeltaV = 6500;

			var parameterList = new List<double>()
			{
				parameters.Apoapsis,
				parameters.Periapsis,
				parameters.Inclination,
				parameters.RequiredDeltaV 
			};

			var expected = new List<double>()
			{
				200000,
				120000,
				-32.22,
				6500
			};

			//Act
			var actual = parameterList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RangeGoof_Succeeded()
		{
			//Arrange
			var parameters = new TrajectoryParameters(103500, 850000, 18.35, 6920);
			var parameterList = new List<double>()
			{
				parameters.Apoapsis,
				parameters.Periapsis,
				parameters.Inclination,
				parameters.RequiredDeltaV
			};

			var expected = new List<double>()
			{
				850000,
				103500,
				18.35,
				6920
			};

			//Act
			var actual = parameterList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

	
		[TestMethod]
		public void NegativeParameter_Succeeded()
		{
			//Arrange
			var parameters = new TrajectoryParameters(103500, -90000, 57.28, 7000);
			var parameterList = new List<double>()
			{
				parameters.Apoapsis,
				parameters.Periapsis,
				parameters.Inclination,
				parameters.RequiredDeltaV
			};

			var expected = new List<double>()
			{
				103500,
				0,
				57.28,
				7000
			};

			//Act
			var actual = parameterList;

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void TrajectoryParameters_ToString()
		{
			//Arrange
			var parameters = new TrajectoryParameters(320000, 318000, 22.36, 6850);
			var oldString = $"Apoapsis: {320000}@Periapsis: {318000}@Inclination: {22.36}@Required DeltaV: {6850}";

			var expected = oldString.Replace("@", "\n");

			//Act
			var actual = parameters.ToString();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}