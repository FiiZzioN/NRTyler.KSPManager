// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
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
using System.Collections.Generic;
using System.Linq;
using NRTyler.CodeLibrary.Utilities;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataControllers
{
	public class DeltaVCalculator
	{
		public static double CalulateDeltaV(Stage stage)
		{
			if (stage == null) throw new ArgumentNullException(nameof(stage), "Argument Was Null");
			
			return CalulateDeltaV(stage.DryMass, stage.WetMass, stage.SpecificImpulse);
		}

		public static double CalulateDeltaV(double dryMass, double wetMass, double? specificImpulse)
		{
			// We have to have a specific impulse in order for our reaction mass to do anything.
			// If we don't have that, in the form of null, zero, or NaN, then we have no delta-v.
			if (specificImpulse == null || specificImpulse <= 0 || Double.IsNaN((double)specificImpulse)) return 0;

			// Tsiolkovsky Rocket Equation, more info here: http://enwp.org/Tsiolkovsky_rocket_equation
			var ve = specificImpulse * ExtendedMathConstants.ɡ;
			var m0 = wetMass;
			var mf = dryMass;
			var ln = Math.Log(m0 / mf);

			var deltaV = ve * ln;

			return (double)deltaV;
		}


		public static double CalculateVehicleDeltaV(IVehicle vehicle)
		{
			if (vehicle == null) throw new ArgumentNullException(nameof(vehicle), "Argument Was Null");

			double totalDeltaV = 0;
			var stages         = vehicle.StageInfo.Values;
			var modifiedStages = new LinkedList<Stage>(stages);
			var node           = modifiedStages.First;

			while (node != null)
			{
				var nodeValue = node.Value;
				var nextNode  = node.Next;
				
				var currentWetMass = nodeValue.WetMass;
				totalDeltaV       += nodeValue.CalculateDeltaV();

				if (nextNode != null)
				{
					var nextNodeValue = nextNode.Value;

					nextNodeValue.DryMass += currentWetMass;
					nextNodeValue.WetMass += currentWetMass;
				}
					
				node = node.Next;
			}

			return totalDeltaV;
		}
	}
}