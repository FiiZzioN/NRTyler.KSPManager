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
	/// An <see cref="Enum"/> holding different flight profiles that a mission can take.
	/// </summary>
	public enum FlightProfile
    {
	    [StringValue("Undefined")]
	    Undefined = 0,

	    [StringValue("Ground Based")]
	    GroundBased = 1,

		[StringValue("Atmospheric Flight")]
        AtmosphericFlight = 2,

        [StringValue("Suborbital")]
        Suborbital = 3,

        [StringValue("Orbital")]
        Orbital = 4,

        [StringValue("Interplanetary")]
        Interplanetary = 5,
    }
}