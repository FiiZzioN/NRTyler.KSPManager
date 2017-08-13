﻿// ***********************************************************************
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
	/// An <see cref="Enum"/> containing various vehicle pacification options.
	/// </summary>
	public enum PacificationType
	{
		[StringValue("Undefined")]
		Undefined = 0,

		[StringValue("Deorbit")]
		Deorbit = 1,

		[StringValue("Graveyard Orbit")]
		GraveyardOrbit = 2,

		[StringValue("Explosion")]
		Explosion = 3,
	}
}