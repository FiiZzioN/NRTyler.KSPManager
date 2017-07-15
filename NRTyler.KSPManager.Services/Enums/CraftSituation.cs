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
	/// An <see cref="Enum"/> containing the various states that any vessel or kerbal can be in.
	/// </summary>
	public enum CraftSituation
    {
        [StringValue("Landed")]
        Landed = 0,

        [StringValue("Suborbital")]
        Suborbital = 1,

        [StringValue("On Orbit")]
        OnOrbit = 2,

        [StringValue("In Flight")]
        InFlight = 3,

        [StringValue("Undefined")]
        Undefined = 4,
    }
}