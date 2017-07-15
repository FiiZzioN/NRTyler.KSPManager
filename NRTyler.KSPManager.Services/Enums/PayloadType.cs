// ***********************************************************************
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

using System;
using NRTyler.CodeLibrary.Attributes;

namespace NRTyler.KSPManager.Services.Enums
{
	/// <summary>
	/// An <see cref="Enum"/> containing the various vessel categories that a payload will fall under.
	/// </summary>
	public enum PayloadType
    {
        [StringValue("Satellite")]
        Satellite = 0,

        [StringValue("Probe")]
        Probe = 1,

        [StringValue("Rover")]
        Rover = 2,

        [StringValue("Lander")]
        Lander = 3,

        [StringValue("Capsule")]
        Capsule = 4,

        [StringValue("Station")]
        Station = 5,

        [StringValue("Base")]
        Base = 6,

        [StringValue("Airplane")]
        Airplane = 7,

        [StringValue("Kerbal")]
        Kerbal = 8,

        [StringValue("Undefined")]
        Undefined = 9,
    }
}