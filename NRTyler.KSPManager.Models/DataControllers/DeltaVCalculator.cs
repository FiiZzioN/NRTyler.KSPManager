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
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.Models.DataControllers
{
	public class DeltaVCalculator
	{
		public static double CalulateDeltaV(Stage stage)
		{
			if (stage == null) throw new ArgumentNullException(nameof(stage), "Argument Was Null");
			if (stage.SpecificImpulse == null || stage.SpecificImpulse <= 0 || Double.IsNaN((double)stage.SpecificImpulse)) return 0;

			var ve = stage.SpecificImpulse * ExtendedMathConstants.ɡ0;
			var m0 = stage.WetMass;
			var mf = stage.DryMass;
			var ln = Math.Log(m0 / mf);

			var deltaV = ve * ln;

			return (double)deltaV;
		}

		public static double CalulateDeltaV(double dryMass, double wetMass, double specificImpulse)
		{
			if (specificImpulse <= 0) return 0;

			var ve = specificImpulse * ExtendedMathConstants.ɡ0;
			var m0 = wetMass;
			var mf = dryMass;
			var ln = Math.Log(m0 / mf);

			var deltaV = ve * ln;

			return deltaV;
		}
	}
}