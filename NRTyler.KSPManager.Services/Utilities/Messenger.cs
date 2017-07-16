// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 07-15-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-15-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.KSPManager.Services.Utilities
{
	/// <summary>
	/// <see cref="Messenger"/> contains methods that help send messages to the console or into log files.
	/// </summary>
	public static class Messenger
	{
		public static string MessageToConsole<T>(string message, params T[] paramaters)
		{
			var formatedString = String.Format(message, paramaters[0]);
			Console.WriteLine(formatedString);
			return formatedString;
		}
	}
}