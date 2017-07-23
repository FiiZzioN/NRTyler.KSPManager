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
using NRTyler.KSPManager.Models.DataControllers;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleItems
{
	/// <summary>
	/// Holds how many days of various life support items are still available.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class LifeSupportSystem : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LifeSupportSystem"/> class.
		/// </summary>
		/// <param name="crewedVehicle">The crewed vehicle.</param>
		public LifeSupportSystem(ICrewable crewedVehicle)
		{
			SupportSettings       = crewedVehicle.LifeSupportSettings;
			ProvisionsStorage     = new ProvisionsStorage();
			WasteStorage          = new WasteStorage();
			LifeSupportCalculator = new LifeSupportCalculator(crewedVehicle);
		}

		private ProvisionsStorage provisionsStorage;
		private WasteStorage wasteStorage;
		private LifeSupportSettings supportSettings;
		private LifeSupportCalculator lifeSupportCalculator;

		private double daysWorthOfFood;
		private double daysWorthOfWater;
		private double daysWorthOfOxygen;
		private double daysWorthOfElectricity;
		private double daysWorthOfWasteStorage;
		private double daysWorthOfWasteWaterStorage;
		private double daysWorthOfCO2Storage;

		/// <summary>
		/// Gets or sets the life support system.
		/// </summary>
		public ProvisionsStorage ProvisionsStorage
		{
			get { return this.provisionsStorage; }
			set { this.provisionsStorage = value; }
		}

		/// <summary>
		/// Gets or sets the waste storage system.
		/// </summary>
		public WasteStorage WasteStorage
		{
			get { return this.wasteStorage; }
			set { this.wasteStorage = value; }
		}

		public LifeSupportSettings SupportSettings
		{
			get { return this.supportSettings; }
			set { this.supportSettings = value; }
		}

		public LifeSupportCalculator LifeSupportCalculator
		{
			get { return this.lifeSupportCalculator; }
			set { this.lifeSupportCalculator = value; }
		}

		public double DaysWorthOfFood
		{
			get
			{
				var unitsPerDay = SupportSettings.FoodPerDay;
				var storage     = ProvisionsStorage.TotalFoodStored;

				DaysWorthOfFood = LifeSupportCalculator.CalculateLifeSupportResources(unitsPerDay, storage);

				return this.daysWorthOfFood;
			}
			set
			{
				if (value < 0) return;

				this.daysWorthOfFood = value;
				OnPropertyChanged(nameof(DaysWorthOfFood));
			}
		}

		public double DaysWorthOfWater
		{
			get
			{
				var unitsPerDay  = SupportSettings.WaterPerDay;
				var storage      = ProvisionsStorage.TotalWaterStored;

				DaysWorthOfWater = LifeSupportCalculator.CalculateLifeSupportResources(unitsPerDay, storage);

				return this.daysWorthOfWater;
			}
			set
			{
				if (value < 0) return;

				this.daysWorthOfWater = value;
				OnPropertyChanged(nameof(DaysWorthOfWater));
			}
		}

		public double DaysWorthOfOxygen
		{
			get
			{
				var unitsPerDay   = SupportSettings.OxygenPerDay;
				var storage       = ProvisionsStorage.TotalOxygenStored;

				DaysWorthOfOxygen = LifeSupportCalculator.CalculateLifeSupportResources(unitsPerDay, storage);

				return this.daysWorthOfOxygen;
			}
			set
			{
				if (value < 0) return;

				this.daysWorthOfOxygen = value;
				OnPropertyChanged(nameof(DaysWorthOfOxygen));
			}
		}


		public double DaysWorthOfElectricity
		{
			get
			{
				var baseUnitsPerDay   = SupportSettings.BaseElectricityPerDay;
				var kerbalUnitsPerDay = SupportSettings.KerbalElectricityPerDay;
				var storage           = ProvisionsStorage.TotalElectricityStored;

				DaysWorthOfElectricity = LifeSupportCalculator.CalculateElectricity(baseUnitsPerDay, kerbalUnitsPerDay, storage);

				return this.daysWorthOfElectricity;
			}
			set
			{
				if (value < 0) return;

				this.daysWorthOfElectricity = value;
				OnPropertyChanged(nameof(DaysWorthOfElectricity));
			}
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