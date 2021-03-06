﻿// ***********************************************************************
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
	/// An <see cref="Enum"/> holding various states that a kerbal can be assigned to in the Astronaut Complex.
	/// </summary>
	public enum LifeStatus
    {
        [StringValue("Available")]
        Available = 0,

        [StringValue("Assigned")]
        OnMission = 1,

        [StringValue("Missing in Action")]
        MIA = 2,

        [StringValue("Killed in Action")]
        KIA = 3,
    }
}