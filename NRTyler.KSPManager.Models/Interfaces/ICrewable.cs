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

using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.Models.Interfaces
{
	/// <summary>
	/// Indicates that an <see cref="IVehicle"/> is capable of holding crew.
	/// </summary>
	public interface ICrewable : IVehicle
	{
        /// <summary>
        /// Gets or sets the number of crew aboard the vehicle.
        /// </summary>
        int NumberOfCrew { get; set; }

        /// <summary>
        /// Gets or sets the life support system the vehicle is using.
        /// </summary>
        LifeSupportSystem LifeSupportSystem { get; set; }
	}
}