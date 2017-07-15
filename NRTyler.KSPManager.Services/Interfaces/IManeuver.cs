﻿// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-14-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

namespace NRTyler.KSPManager.Services.Interfaces
{
	/// <summary>
	/// Indicates that a given type can execute a maneuver.
	/// </summary>
	public interface IManeuver
	{
		double RequiredDeltaV { get; set; }
	}
}