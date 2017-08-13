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
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.Interfaces;
using NRTyler.KSPManager.Services.Utilities;

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
			if (specificImpulse == null || specificImpulse <= 0 || Double.IsNaN((double)specificImpulse)) return 0;

			var ve = specificImpulse * ExtendedMathConstants.ɡ0;
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