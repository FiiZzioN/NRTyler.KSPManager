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
	/// An <see cref="Enum"/> containing the various specializations that a kerbal will be assigned to.
	/// </summary>
	public enum Specialization
    {
	    [StringValue("Undefined")]
	    Undefined = 0,

		[StringValue("Pilot")]
        Pilot = 1,

        [StringValue("Scientist")]
        Scientist = 2,

        [StringValue("Engineer")]
        Engineer = 3,

        [StringValue("Tourist")]
        Tourist = 4,
    }
}