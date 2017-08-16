// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Common
//
// Author           : Nicholas Tyler
// Created          : 08-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.KSPManager.Common.Utilities
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
		/// <exception cref="ArgumentNullException"></exception>
		public static void EnsureProperAssignment<T>(ref T smallerValue, ref T largerValue) where T : IComparable<T>
		{
			if (smallerValue == null) throw new ArgumentNullException(nameof(smallerValue), "Incoming value was null.");
			if (largerValue  == null) throw new ArgumentNullException(nameof(largerValue) , "Incoming value was null.");

			// Smaller should precede larger.
			if (smallerValue.CompareTo(largerValue) < 0) return;

			// Make new fields to preserve values.
			var smaller = smallerValue;
			var larger  = largerValue;

			// Put the values in their proper position.
			smallerValue = larger;
			largerValue  = smaller;
		}
	}
}