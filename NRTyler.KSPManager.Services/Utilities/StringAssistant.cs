// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Globalization;

namespace NRTyler.KSPManager.Services.Utilities
{
	public static class StringAssistant
	{
		/// <summary>
		/// Gets the value returned in the current cultures title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToTitleCase(string value)
		{
			if (value == null) return null;
			
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}

		/// <summary>
		/// Gets the value returned in a culture-independent (invariant) title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToInvariantTitleCase(string value)
		{
			if (value == null) return null;

			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
		}

		/// <summary>
		/// Insures that a field meant to be a title will never be null.
		/// </summary>
		/// <param name="incomingValue">The incoming value.</param>
		/// <param name="backingField">The backing field that's meant to be a title.</param>
		public static void TitleInsurance(string incomingValue, ref string backingField)
		{
			if (String.IsNullOrWhiteSpace(incomingValue))
			{
				var titleIfNull  = "Invalid Title";
				if (backingField == titleIfNull) return;

				backingField = titleIfNull;
				return;
			}

			backingField = incomingValue;
		}
	}
}