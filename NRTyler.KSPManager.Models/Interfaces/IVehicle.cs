// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Services.Enums;

namespace NRTyler.KSPManager.Models.Interfaces
{
	public interface IVehicle : IValuable
	{
		string Name { get; set; }
		decimal Mass { get; set; }
		SortedDictionary<int, Stage> StageInfo { get; set; }
		List<VehicleNote> VehicleNotes { get; set; }
		List<PacificationOption> PacificationOptions { get; set; }
		VehicleType VehicleType { get; set; }
	}
}