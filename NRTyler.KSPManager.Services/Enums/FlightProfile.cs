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
using NRTyler.KSPManager.Services.Attributes;

namespace NRTyler.KSPManager.Services.Enums
{
	/// <summary>
	/// An <see cref="Enum"/> holding different flight profiles that a mission can take.
	/// </summary>
	public enum FlightProfile
    {
        [StringValue("Atmospheric Flight")]
        AtmosphericFlight = 0,

        [StringValue("Suborbital")]
        Suborbital = 1,

        [StringValue("Orbital")]
        Orbital = 2,

        [StringValue("Interplanetary")]
        Interplanetary = 3,

        [StringValue("Undefined")]
        Undefined = 4,
    }
}