// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-23-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

#region Using Statements
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.Interfaces;
using NRTyler.KSPManager.Services.Enums;
using NRTyler.KSPManager.Services.Utilities;	
#endregion

namespace NRTyler.KSPManager.Models.DataProviders.VehicleTypes
{
	public class CrewedVehicle : ICrewable, INotifyPropertyChanged
	{
		public CrewedVehicle()
		{
			VehicleType       = VehicleType.Undefined;
			StageInfo         = new SortedDictionary<int, Stage>();
			VehicleNotes      = new List<VehicleNote>();
		}

		public CrewedVehicle(BaseGameSettings baseSettings, LifeSupportSettings supportSettings) : this()
		{
			BaseGameSettings = baseSettings;
			LifeSupportSettings = supportSettings;
			LifeSupportSystem = new LifeSupportSystem(this);
		}


		#region Backing Fields

		private decimal price;
		private string name;
		private double dryMass;
		private double wetMass;
		private double deltaV;
		private SortedDictionary<int, Stage> stageInfo;
		private List<VehicleNote> vehicleNotes;
		private VehicleType vehicleType;
		private int numberOfCrew;
		private LifeSupportSystem lifeSupportSystem;
		private BaseGameSettings baseGameSettings;
		private LifeSupportSettings lifeSupportSettings;

		#endregion

		#region Properties

		#region Implementation of IValuable

		/// <summary>
		/// Gets or sets the price of the vehicle.
		/// </summary>
		public decimal Price
		{
			get { return this.price; }
			set
			{
				if (value < 0) return;

				this.price = value;
				OnPropertyChanged(nameof(Price));
			}
		}

		#endregion

		#region Implementation of IVehicle

		/// <summary>
		/// Gets or sets the name of the vehicle.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set
			{
				StringAssistant.TitleInsurance(value, ref this.name);
				OnPropertyChanged(nameof(this.Name));
			}
		}

		/// <summary>
		/// Gets or sets the vehicle's dry mass.
		/// </summary>
		public double DryMass
		{
			get { return this.dryMass; }
			set
			{
				if (value < 0) return;

				this.dryMass = value;
				OnPropertyChanged(nameof(this.DryMass));
			}
		}

		/// <summary>
		/// Gets or sets the total wet mass of the vehicle.
		/// </summary>
		public double WetMass
		{
			get { return this.wetMass; }
			set
			{
				if (value < 0) return;

				this.wetMass = value;
				OnPropertyChanged(nameof(this.WetMass));
			}
		}

		/// <summary>
		/// Gets or sets the total amount of Delta V available to the vehicle.
		/// </summary>
		public double DeltaV
		{
			get { return this.deltaV; }
			set
			{
				if (value < 0) return;

				this.deltaV = value;
				OnPropertyChanged(nameof(this.DeltaV));
			}
		}

		/// <summary>
		/// Gets or sets the type of the vehicle.
		/// </summary>
		public VehicleType VehicleType
		{
			get { return this.vehicleType; }
			set
			{
				this.vehicleType = value;
				OnPropertyChanged(nameof(this.VehicleType));
			}
		}

		/// <summary>
		/// Gets or sets the dictionary of stage information.
		/// </summary>
		public SortedDictionary<int, Stage> StageInfo
		{
			get { return this.stageInfo; }
			set
			{
				this.stageInfo = value;
				OnPropertyChanged(nameof(this.StageInfo));
			}
		}

		/// <summary>
		/// Gets or sets the dictionary of vehicle notes.
		/// </summary>
		public List<VehicleNote> VehicleNotes
		{
			get { return this.vehicleNotes; }
			set
			{
				this.vehicleNotes = value;
				OnPropertyChanged(nameof(this.VehicleNotes));
			}
		}

		#endregion

		#region Implementation of ICrewable

		/// <summary>
		/// Gets or sets the number of crew on board the vehicle.
		/// </summary>
		public int NumberOfCrew
		{
			get { return this.numberOfCrew; }
			set
			{
				if (value < 0) return;

				this.numberOfCrew = value;
				OnPropertyChanged(nameof(NumberOfCrew));
			}
		}

		/// <summary>
		/// Gets or sets information about the life support system.
		/// </summary>
		public LifeSupportSystem LifeSupportSystem
		{
			get { return this.lifeSupportSystem; }
			set
			{
				this.lifeSupportSystem = value;
				OnPropertyChanged(nameof(LifeSupportSystem));
			}
		}

		/// <summary>
		/// Gets the base game settings.
		/// </summary>
		public BaseGameSettings BaseGameSettings
		{
			get { return this.baseGameSettings; }
			private set
			{
				this.baseGameSettings = value;
				OnPropertyChanged(nameof(BaseGameSettings));
			}
		}

		/// <summary>
		/// Gets the life support settings.
		/// </summary>
		public LifeSupportSettings LifeSupportSettings
		{
			get { return this.lifeSupportSettings; }
			private set
			{
				this.lifeSupportSettings = value;
				OnPropertyChanged(nameof(LifeSupportSettings));
			}
		}

		#endregion

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