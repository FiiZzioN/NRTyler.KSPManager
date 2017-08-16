// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Common
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
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
	/// An <see cref="Enum"/> containing the name and numerical value for a given level.
	/// </summary>
	public enum BuildingLevel
    {
        [StringValue("One")]
        One = 0,

        [StringValue("Two")]
        Two = 1,

        [StringValue("Three")]
        Three = 2,
    }
}