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
	/// An <see cref="Enum"/> containing the various categories that any given vehicle will fall under.
	/// </summary>
	[Serializable]
	public enum VehicleType
    {
	    [StringValue("Undefined")]
	    Undefined = 0,

		[StringValue("Satellite")]
        Satellite = 1,

        [StringValue("Probe")]
        Probe = 2,

        [StringValue("Rover")]
        Rover = 3,

        [StringValue("Lander")]
        Lander = 4,

        [StringValue("Capsule")]
        Capsule = 5,

        [StringValue("Station")]
        Station = 6,

        [StringValue("Base")]
        Base = 7,

        [StringValue("Airplane")]
        Airplane = 8,

        [StringValue("Kerbal")]
        Kerbal = 9,

	    [StringValue("Launch Vehicle")]
	    LaunchVehicle = 10,
	}
}