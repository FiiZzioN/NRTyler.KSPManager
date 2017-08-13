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
	    [StringValue("Undefined")]
	    Undefined = 0,

		[StringValue("Manned")]
        Manned = 1,

        [StringValue("Unmanned")]
        Unmanned = 2,

        [StringValue("Asteroid Redirect")]
        AsteroidRedirect = 3,

        [StringValue("Contract")]
        Contract = 4,

        [StringValue("Deorbit Debris")]
        DeorbitDebris = 5,

        [StringValue("Exploration")]
        Exploration = 6,

        [StringValue("ISRU")]
        ISRU = 7,

        [StringValue("Impactor")]
        Impactor = 8,

        [StringValue("Mapping")]
        Mapping = 9,

        [StringValue("Rescue")]
        Rescue = 10,

        [StringValue("Research")]
        Research = 11,

        [StringValue("Resupply")]
        Resupply = 12,

        [StringValue("Survey")]
        Survey = 13,
        
        [StringValue("Tourism")]
        Tourism = 14,


    }
}