﻿// ***********************************************************************
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

namespace NRTyler.KSPManager.Models.Interfaces
{
	/// <summary>
	/// Indicates that a given type can execute a maneuver.
	/// </summary>
	public interface IBurn
	{
		double RequiredDeltaV { get; set; }
	}
}