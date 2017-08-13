// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 08-12-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-12-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleItems
{
	public class OptionalBoostStage : Stage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OptionalBoostStage"/> class.
		/// </summary>
		/// <param name="payload">The payload.</param>
		public OptionalBoostStage(IVehicle payload)
		{
			Payload = payload;
		}

		private IVehicle payload;

		/// <summary>
		/// Gets or sets the payload.
		/// </summary>
		public IVehicle Payload
		{
			get { return this.payload; }
			set
			{
				this.payload = value;
				OnPropertyChanged(nameof(Payload));
			}
		}

		#region Overrides of Stage

		/// <summary>
		/// Calculates the stage's total delta-v.
		/// </summary>
		/// <returns>System.Double.</returns>
		public override double CalculateDeltaV()
		{
			// When an optional stage is used, it needs to know what else is there mass-wise
			// in order to correctly calculate the delta-v.
			DryMass += Payload.WetMass;

			return DeltaVCalculator.CalulateDeltaV(this);
		}

		#endregion
	}
}