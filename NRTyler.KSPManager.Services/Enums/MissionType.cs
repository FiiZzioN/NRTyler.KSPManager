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
	/// An <see cref="Enum"/> containing various items that will help describe what the mission was about.
	/// </summary>
	public enum MissionType
    {
        [StringValue("Manned")]
        Manned = 0,

        [StringValue("Unmanned")]
        Unmanned = 1,

        [StringValue("Asteroid Redirect")]
        AsteroidRedirect = 2,

        [StringValue("Contract")]
        Contract = 3,

        [StringValue("Deorbit Debris")]
        DeorbitDebris = 4,

        [StringValue("Exploration")]
        Exploration = 5,

        [StringValue("ISRU")]
        ISRU = 6,

        [StringValue("Impactor")]
        Impactor = 7,

        [StringValue("Mapping")]
        Mapping = 8,

        [StringValue("Rescue")]
        Rescue = 9,

        [StringValue("Research")]
        Research = 10,

        [StringValue("Resupply")]
        Resupply = 11,

        [StringValue("Survey")]
        Survey = 12,
        
        [StringValue("Tourism")]
        Tourism = 13,

        [StringValue("Undefined")]
        Undefined = 14,
    }
}