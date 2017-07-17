// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-16-2017
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
		public Vehicle()
		{

		}

		public Vehicle(string name)
		{
			Name = name;
		}

		private string name;
		private decimal? price;
		private Dictionary<string, string> vehicleNotes;
		private Dictionary<int, Stage> stageInfo;
		private Dictionary<string, decimal> pacificationOptions;
		private VehicleType vehicleType;

		#region Implementation of IVehicle

		public string Name
		{
			get { return this.name; }
			set
			{
				StringAssistant.TitleInsurance(value, ref this.name);
				OnPropertyChanged(nameof(Name));
			}
		}

		public Dictionary<string, string> VehicleNotes
		{
			get { return this.vehicleNotes; }
			set { this.vehicleNotes = value; }
		}

		public Dictionary<int, Stage> StageInfo
		{
			get { return this.stageInfo; }
			set { this.stageInfo = value; }
		}

		public Dictionary<string, decimal> PacificationOptions
		{
			get { return this.pacificationOptions; }
			set { this.pacificationOptions = value; }
		}

		public VehicleType VehicleType
		{
			get { return this.vehicleType; }
			set { this.vehicleType = value; }
		}

		#endregion

		#region Implementation of IValuable

		/// <summary>
		/// Gets or sets the price of an object.
		/// </summary>
		public decimal? Price
		{
			get { return this.price; }
			set { this.price = value; }
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