// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ConsoleAid
//
// Author           : Nicholas Tyler
// Created          : 07-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			double? valueOne = 123;
			double? valueTwo = 32;

			valueTwo = null;

			EntryValidator.EnsureProperAssignment(ref valueOne, ref valueTwo);

			Console.WriteLine(valueOne);
			Console.WriteLine(valueTwo);
		}
	}
}
