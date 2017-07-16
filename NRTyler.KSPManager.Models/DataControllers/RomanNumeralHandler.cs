// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-15-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-15-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.Models.DataControllers
{
	/// <summary>
	/// Helps properly display roman numerals in an <see cref="ObjectName"/>.
	/// </summary>
	public class RomanNumeralHandler
	{
		public RomanNumeralHandler()
		{
			
		}

		/// <summary>
		/// Handles converting roman numerals in an <see cref="ObjectName"/> to uppercase when using the "ToTitleCase" methods.
		/// </summary>
		/// <param name="value">The name that's to be checked for roman numerals.</param>
		/// <returns>System.String.</returns>
		public static string HandleRomanNumerals(string value)
		{
			// Ordered in such a way that if a name includes "Iii", it won't pick "Ii" because it was found first.
			// Expand upon later.
			var romanNumeralArray = new[] { "Iii", "Ii", "Iv", "Viii", "Vii", "Vi", "Ix" };

			foreach (var numeral in romanNumeralArray)
			{
				if (value.Contains(numeral))
				{
					return value.Replace(numeral, numeral.ToUpper());
				}
			}

			return value;
		}
	}
}