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
	/// An <see cref="Enum"/> containing the various progression states that any given mission will fall under.
	/// </summary>
	public enum MissionState
    {
        [StringValue("Planning")]
        Planning = 0,

        [StringValue("Ongoing")]
        Ongoing = 1,

        [StringValue("Complete")]
        Complete = 2,
    }
}