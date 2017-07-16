// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ConsoleAid
//
// Author           : Nicholas Tyler
// Created          : 07-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-13-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			var name = new ObjectName("delta iii");

			name.ToInvariantTitleCase();
		}
	}
}
