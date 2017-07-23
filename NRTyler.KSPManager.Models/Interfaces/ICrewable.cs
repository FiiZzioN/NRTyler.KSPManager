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

using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.Models.Interfaces
{
	/// <summary>
	/// Indicates that an <see cref="IVehicle"/> is capable of holding crew.
	/// </summary>
	public interface ICrewable : IVehicle
	{
		int NumberOfCrew { get; set; }

		LifeSupportSystem LifeSupportSystem { get; set; }

		BaseGameSettings BaseGameSettings { get; }

		LifeSupportSettings LifeSupportSettings { get; }
	}
}