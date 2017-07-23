// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders.GameSettings
{
	/// <summary>
	/// Holds information about how many units are used / generated of various life support systems per day. 
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class LifeSupportSettings : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LifeSupportSettings"/> class.
		/// </summary>
		public LifeSupportSettings()
		{
			InitializeClass();
		}

		private double foodPerDay;
		private double waterPerDay;
		private double oxygenPerDay;
		private double baseElectricityPerDay;
		private double kerbalElectricityPerDay;

		private double wastePerDay;
		private double wasteWaterPerDay;
		private double co2PerDay;

		#region Properties

		/// <summary>
		/// Gets or sets the units of food consumed per day.
		/// </summary>
		public double FoodPerDay
		{
			get { return this.foodPerDay; }
			set
			{
				if (value < 0) return;

				this.foodPerDay = value;
				OnPropertyChanged(nameof(FoodPerDay));
			}
		}

		/// <summary>
		/// Gets or set the units of water consumed per day.
		/// </summary>
		public double WaterPerDay
		{
			get { return this.waterPerDay; }
			set
			{
				if (value < 0) return;

				this.waterPerDay = value;
				OnPropertyChanged(nameof(WaterPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the units of oxygen consumed per day.
		/// </summary>
		public double OxygenPerDay
		{
			get { return this.oxygenPerDay; }
			set
			{
				if (value < 0) return;

				this.oxygenPerDay = value;
				OnPropertyChanged(nameof(OxygenPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the baseline units of electricity consumed per day.
		/// </summary>
		public double BaseElectricityPerDay
		{
			get { return this.baseElectricityPerDay; }
			set
			{
				if (value < 0) return;

				this.baseElectricityPerDay = value;
				OnPropertyChanged(nameof(BaseElectricityPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the units of electricity a kerbal consumes per day.
		/// </summary>
		public double KerbalElectricityPerDay
		{
			get { return kerbalElectricityPerDay; }
			set
			{
				if (value < 0) return;

				this.kerbalElectricityPerDay = value;
				OnPropertyChanged(nameof(KerbalElectricityPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the units of waste produced per day.
		/// </summary>
		public double WastePerDay
		{
			get { return this.wastePerDay; }
			set
			{
				if (value < 0) return;

				this.wastePerDay = value;
				OnPropertyChanged(nameof(WaterPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the units of waste water produced per day.
		/// </summary>
		public double WasteWaterPerDay
		{
			get { return this.wasteWaterPerDay; }
			set
			{
				if (value < 0) return;

				this.wasteWaterPerDay = value;
				OnPropertyChanged(nameof(WasteWaterPerDay));
			}
		}

		/// <summary>
		/// Gets or sets the units of CO2 produced per day.
		/// </summary>
		public double CO2PerDay
		{
			get { return this.co2PerDay; }
			set
			{
				if (value < 0) return;

				this.co2PerDay = value;
				OnPropertyChanged(nameof(this.co2PerDay));
			}
		}

		#endregion

		/// <summary>
		/// Initializes the class with default values.
		/// </summary>
		private void InitializeClass()
		{
			FoodPerDay              = 0.365625;
			WaterPerDay             = 0.241663;
			OxygenPerDay            = 37.01241;
			BaseElectricityPerDay   = 459;
			KerbalElectricityPerDay = 306;
			WastePerDay             = 0.03325;
			WasteWaterPerDay        = 0.30775;
			CO2PerDay               = 31.97079;
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