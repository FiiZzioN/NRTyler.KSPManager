// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
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
		Dictionary<string, string> VehicleNotes { get; set; }
		Dictionary<string, StageBreakdown> StageInfo { get; set; }
		Dictionary<string, decimal> PacificationOptions { get; set; }
		VehicleType VehicleType { get; set; }
	}
}