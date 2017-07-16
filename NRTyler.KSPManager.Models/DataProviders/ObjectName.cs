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

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.DataControllers;

namespace NRTyler.KSPManager.Models.DataProviders
{
	/// <summary>
	/// This class holds a field if an <see cref="object"/> needs a name. It also contains methods for modifying said name to various title cases should it need to be displayed.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class ObjectName : INotifyPropertyChanged
	{
		public ObjectName(string name)
		{
			Name = name;
			Console.WriteLine(this);
		}

		private string name;

		public string Name
		{
			get { return this.name; }
			set
			{ 
				if (String.IsNullOrWhiteSpace(value))
				{
					var nameIfNull = "Value Was Null";

					if (this.name == nameIfNull) return;
					this.name = nameIfNull;
					return;
				}

				this.name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		#region Helper Methods

		/// <summary>
		/// Helps the overridden "ToString" method, and any other method outputting to the console, format it's output.
		/// </summary>
		/// <param name="value">The dynamic string.</param>
		/// <returns>System.String.</returns>
		private static string ToStringHelper(string value)
		{
			return $"Name: {value}";
		}

		#endregion

		#region Instance Methods

		/// <summary>
		/// Gets the name exactly as it was set.
		/// </summary>
		/// <returns>System.String.</returns>
		public string GetName()
		{
			return Name;
		}

		/// <summary>
		/// Gets the name in the current cultures title case.
		/// </summary>
		/// <returns>System.String.</returns>
		public string ToTitleCase()
		{
			return ToTitleCase(this.Name);
		}

		/// <summary>
		/// Gets the name in a culture-independent (invariant) title case.
		/// </summary>
		/// <returns>System.String.</returns>
		public string ToInvariantTitleCase()
		{
			return ToInvariantTitleCase(this.Name);
		}

		#endregion

		#region Static Methods

		/// <summary>
		/// Gets the value returned in the current cultures title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToTitleCase(string value)
		{
			var nameTitleCased = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
			var numeralsHandled = RomanNumeralHandler.HandleRomanNumerals(nameTitleCased);
			Console.WriteLine(ToStringHelper(numeralsHandled));

			return numeralsHandled;
		}

		/// <summary>
		/// Gets the value returned in a culture-independent (invariant) title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToInvariantTitleCase(string value)
		{
			var nameTitleCased = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
			var numeralsHandled = RomanNumeralHandler.HandleRomanNumerals(nameTitleCased);
			Console.WriteLine(ToStringHelper(numeralsHandled));

			return numeralsHandled;
		}

		#endregion

		#region Overrides of Object

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return ToStringHelper(this.Name);
		}

		#endregion

		#region INotifyPropertyChanged Members

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Called when [property changed].
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}