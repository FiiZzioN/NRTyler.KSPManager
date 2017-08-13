// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Services.Enums;

namespace NRTyler.KSPManager.Models.Interfaces
{
	/// <summary>
	/// Contains items that any type of vehicle should have.
	/// </summary>
	/// <seealso cref="NRTyler.KSPManager.Models.Interfaces.IValuable" />
	public interface IVehicle : IHasDeltaV, IValuable
	{
		/// <summary>
		/// Gets or sets the vehicle's the name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the vehicle's dry mass.
		/// </summary>
		double DryMass { get; set; }

		/// <summary>
		/// Gets or sets vehicle's the wet mass.
		/// </summary>
		double WetMass { get; set; }

		/// <summary>
		/// Gets or sets the vehicle's stage information.
		/// </summary>
		SortedDictionary<int, Stage> StageInfo { get; set; }

		/// <summary>
		/// Gets or sets the vehicles notes.
		/// </summary>
		List<VehicleNote> VehicleNotes { get; set; }

		/// <summary>
		/// Gets or sets the type of the vehicle.
		/// </summary>
		VehicleType VehicleType { get; set; }
	}
}