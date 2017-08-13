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

namespace NRTyler.KSPManager.Models.Interfaces
{
	public interface IHasDeltaV
	{
		/// <summary>
		/// Gets or sets the delta-v.
		/// </summary>
		double DeltaV { get; set; }

		/// <summary>
		/// Calculates the delta-v.
		/// </summary>
		/// <returns>System.Double.</returns>
		double CalculateDeltaV();
	}
}