// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.Interfaces;
using NRTyler.KSPManager.Services.Enums;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.Models.DataProviders
{
	public class Vehicle : IVehicle, INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		public Vehicle()
		{
			VehicleType         = VehicleType.Undefined;
			StageInfo           = new SortedDictionary<int, Stage>();
			VehicleNotes        = new List<VehicleNote>();
			PacificationOptions = new List<PacificationOption>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="name">The name of the vehicle.</param>
		public Vehicle(string name) : this()
		{
			Name = name;
		}

		#region Backing Fields

		private string name;
		private decimal mass;
		private decimal? price;
		private VehicleType vehicleType;
		private SortedDictionary<int, Stage> stageInfo;
		private List<VehicleNote> vehicleNotes;
		private List<PacificationOption> pacificationOptions;
		
		#endregion

		#region Implementation of IVehicle

		/// <summary>
		/// Gets or sets the name of the vehicle.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return this.name; }
			set
			{
				StringAssistant.TitleInsurance(value, ref this.name);
				OnPropertyChanged(nameof(Name));
			}
		}

		/// <summary>
		/// Gets or sets the mass of the vehicle.
		/// </summary>
		public decimal Mass
		{
			get { return this.mass; }
			set
			{
				if (value < 0) return;
				this.mass = value;
				OnPropertyChanged(nameof(Mass));
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
				OnPropertyChanged(nameof(VehicleType));
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
				OnPropertyChanged(nameof(StageInfo));
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
				OnPropertyChanged(nameof(VehicleNotes));
			}
		}

		/// <summary>
		/// Gets or sets the dictionary of pacification options.
		/// </summary>
		public List<PacificationOption> PacificationOptions
		{
			get { return this.pacificationOptions; }
			set
			{
				this.pacificationOptions = value;
				OnPropertyChanged(nameof(Price));
			}
		}

		#endregion

		#region Implementation of IValuable

		/// <summary>
		/// Gets or sets the price of the vehicle.
		/// </summary>
		public decimal? Price
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