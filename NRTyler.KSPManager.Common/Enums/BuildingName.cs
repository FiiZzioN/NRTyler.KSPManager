// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Common
//
// Author           : Nicholas Tyler
// Created          : 08-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Attributes;

namespace NRTyler.KSPManager.Common.Enums
{
	/// <summary>
	/// An <see cref="Enum"/> that holds the names of various buildings around the KSC.
	/// </summary>
	public enum BuildingName
	{
		[StringValue("Vehicle Assembly Building")]
		VAB = 0,

		[StringValue("Launchpad")]
		LaunchPad = 1,

		[StringValue("Spaceplane Hangar")]
		SPH = 2,

		[StringValue("Runway")]
		Runway = 3,

		[StringValue("Tracking Station")]
		TrackingStation = 4,

		[StringValue("Astronaut Complex")]
		AstronautComplex = 5,

		[StringValue("Research And Development")]
		RND = 6,

		[StringValue("Mission Control")]
		MissionControl = 7,

		[StringValue("Administration Building")]
		Administration = 8,
	}
}