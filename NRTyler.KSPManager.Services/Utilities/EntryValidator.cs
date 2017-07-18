// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 07-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.KSPManager.Services.Utilities
{
	/// <summary>
	/// <see cref="EntryValidator"/> is all about making sure values are assigned to their proper locations.
	/// </summary>
	public static class EntryValidator
	{
		/// <summary>
		/// Ensures that a smaller value and a larger value will be in their proper field. Before calling this method, make sure that both variables have had a value assigned to them.
		/// </summary>
		/// <typeparam name="T">The type of the value to be compared.</typeparam>
		/// <param name="smallerValue">The smaller value's backing field.</param>
		/// <param name="largerValue">The larger value's backing field.</param>
		/// <exception cref="ArgumentNullException">
		/// smallerValue - Incoming value was null.
		/// or
		/// largerValue - Incoming value was null.
		/// </exception>
		public static void EnsureProperAssignment<T>(ref T smallerValue, ref T largerValue)
		{
			//if (smallerValue == null) return;
			//if (largerValue  == null) return;
			if (smallerValue == null) throw new ArgumentNullException(nameof(smallerValue), "Incoming value was null.");
			if (largerValue  == null) throw new ArgumentNullException(nameof(largerValue) , "Incoming value was null.");

			dynamic smaller = smallerValue;
			dynamic larger = largerValue;

			if (smaller < larger) return;

			smallerValue = larger;
			largerValue = smaller;
		}
	}
}