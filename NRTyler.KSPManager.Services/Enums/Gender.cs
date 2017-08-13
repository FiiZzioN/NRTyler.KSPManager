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
	/// An <see cref="Enum"/> holding the available genders that a kerbal can be assigned to.
	/// </summary>
	public enum Gender
    {
        [StringValue("Male")]
        Male = 0,

        [StringValue("Female")]
        Female = 1,
    }
}