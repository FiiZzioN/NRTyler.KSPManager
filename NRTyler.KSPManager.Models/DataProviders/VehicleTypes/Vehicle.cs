// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.Interfaces;
using NRTyler.KSPManager.Services.Enums;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleTypes
{
	public class Vehicle : IVehicle, INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		public Vehicle()
		{
			this.VehicleType  = VehicleType.Undefined;
			this.StageInfo    = new SortedDictionary<int, Stage>();
			this.VehicleNotes = new List<VehicleNote>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="name">The name of the vehicle.</param>
		public Vehicle(string name) : this()
		{
			this.Name = name;
		}

		#region Backing Fields
		 
		private string name;
		private double dryMass;
		private double wetMass;
		private double deltaV;
		private decimal price;
		private VehicleType vehicleType;
		private SortedDictionary<int, Stage> stageInfo;
		private List<VehicleNote> vehicleNotes;
		
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
		/// Gets or sets the total dry mass of the vehicle.
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
		/// Gets or sets the total price of the vehicle.
		/// </summary>
		public decimal Price
		{
			get { return this.price; }
			set
			{
				if (value < 0) return;
				this.price = value;
				OnPropertyChanged(nameof(this.Price));
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