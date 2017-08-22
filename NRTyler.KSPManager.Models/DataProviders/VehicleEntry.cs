﻿// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.CodeLibrary.Extensions;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataProviders
{
	/// <summary>
	/// Holds the basic information about a vehicle when looking through the collection of vehicles.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	[Serializable]
	public class VehicleEntry : INotifyPropertyChanged
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="VehicleEntry"/> class.
		/// </summary>
		public VehicleEntry()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="VehicleEntry"/> class.
		/// </summary>
		/// <param name="vehicle">The vehicle that this entry will represent.</param>
		public VehicleEntry(IVehicle vehicle)
		{
			AddToEntry(vehicle);
		}

		#endregion

		private IVehicle vehicle;
		private VehicleType vehicleType;
		private string name;
		private decimal price;

		#region Properties

		public IVehicle Vehicle
		{
			get { return this.vehicle; }
			set
			{
				if (value == this.vehicle) return;

				this.vehicle = value; 
				OnPropertyChanged(nameof(Vehicle));
			}
		}

		public VehicleType VehicleType
		{
			get { return this.vehicleType; }
			set
			{
				if (value == this.vehicleType) return;

				this.vehicleType = value; 
				OnPropertyChanged(nameof(VehicleType));
			}
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value == this.name) return;

				value.TitleInsurance(ref this.name);
				OnPropertyChanged(nameof(Name));
			}
		}

		public decimal Price
		{
			get { return this.price; }
			set
			{
				if (value < 0 || value == this.price) return;

				this.price = value;
				OnPropertyChanged(nameof(Price));
			}
		}

		#endregion

		/// <summary>
		/// Adds to entry.
		/// </summary>
		/// <param name="value">The vehicle that you want this entry to represent.</param>
		public void AddToEntry(IVehicle value)
		{
			Vehicle = value;
			Name    = value.Name;
			Price   = value.Price;
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
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}