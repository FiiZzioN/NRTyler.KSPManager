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
	/// An <see cref="Enum"/> containing the various states that any vessel or kerbal can be in.
	/// </summary>
	public enum CraftSituation
    {
	    [StringValue("Undefined")]
	    Undefined = 0,

	    [StringValue("In Vehicle Assembly Building")]
	    InsideVAB = 1,

	    [StringValue("In SpacePlane Hanger")]
	    InsideSPH = 2,

		[StringValue("Landed")]
        Landed = 3,

        [StringValue("Suborbital")]
        Suborbital = 4,

        [StringValue("On Orbit")]
        OnOrbit = 5,

        [StringValue("In Flight")]
        InFlight = 6,
    }
}