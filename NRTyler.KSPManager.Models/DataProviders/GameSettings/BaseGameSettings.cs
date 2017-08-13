// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-12-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders.GameSettings
{
	/// <summary>
	/// Holds information from the base game settings.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class BaseGameSettings : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseGameSettings"/> class.
		/// </summary>
		public BaseGameSettings()
		{
			InitializeClass();
		}

		public const int DefaultHoursInKerbinDay = 6;

		private double dayLengthMultiplier;
		private double solarSystemScale;
		private bool usingLifeSupport;

		/// <summary>
		/// Gets or sets the amount of hours that are in a Kerbin day.
		/// </summary>
		public double DayLengthMultiplier
		{
			get { return this.dayLengthMultiplier; }
			set
			{
				if (value < 0) return;
					
				this.dayLengthMultiplier = value;
				OnPropertyChanged(nameof(DayLengthMultiplier));
			}
		}

		/// <summary>
		/// Gets or sets the solar system scale.
		/// </summary>
		public double SolarSystemScale
		{
			get { return this.solarSystemScale; }
			set
			{
				if (value < 0) return;

				this.solarSystemScale = value;
				OnPropertyChanged(nameof(this.SolarSystemScale));
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the player is using a life support mod.
		/// </summary>
		public bool UsingLifeSupport
		{
			get { return usingLifeSupport; }
			set
			{
				usingLifeSupport = value;
				OnPropertyChanged(nameof(UsingLifeSupport));
			}
		}

		private void InitializeClass()
		{
			DayLengthMultiplier = 1;
			SolarSystemScale = 1;
			UsingLifeSupport = false;
		}

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