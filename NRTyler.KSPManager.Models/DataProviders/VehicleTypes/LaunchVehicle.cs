// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleTypes
{
    /// <summary>
    /// Holds information that any launch vehicle should contain. This class can not only hold the same information that
    /// a <see cref="Vehicle"/> can contain, but also holds lift capability, fairing, and booster pacification options.
    /// </summary>
    /// <seealso cref="NRTyler.KSPManager.Models.DataProviders.VehicleTypes.Vehicle" />
    public class LaunchVehicle : Vehicle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LaunchVehicle"/> class.
		/// </summary>
		public LaunchVehicle() : this("Name Not Set")
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LaunchVehicle"/> class.
		/// </summary>
		/// <param name="name">The name of the vehicle.</param>
		public LaunchVehicle(string name)
		{
			VehicleType         = VehicleType.LaunchVehicle;
			StageInfo           = new SortedDictionary<int, Stage>();
			VehicleNotes        = new List<VehicleNote>();
			OptionalStages      = new List<Stage>();
			Fairings            = new Dictionary<string, Fairing>();
			Capability          = new Dictionary<string, VehicleCapability>();
			PacificationOptions = new Dictionary<string, PacificationOption>();

			Name = name;
		}

		#region Backing Fields

		private Dictionary<string, Fairing> fairings;
		private Dictionary<string, VehicleCapability> capability;
		private Dictionary<string, PacificationOption> pacificationOptions;

		#endregion

		/// <summary>
		/// Gets or sets the fairing options that are available to this vehicle.
		/// </summary>
		public Dictionary<string, Fairing> Fairings
		{
			get { return this.fairings; }
			set
			{
				this.fairings = value;
				OnPropertyChanged(nameof(Fairings));
			}
		}

		/// <summary>
		/// Gets or sets the types of trajectories you can reach and the payload range you can place there.
		/// </summary>
		public Dictionary<string, VehicleCapability> Capability
		{
			get { return this.capability; }
			set
			{
				this.capability = value;
				OnPropertyChanged(nameof(Capability));
			}
		}

		/// <summary>
		/// Gets or sets the collection of ways that the entire vehicle, or the discarded boost stage left in orbit can be pacified.
		/// </summary>
		public Dictionary<string, PacificationOption> PacificationOptions
		{
			get { return this.pacificationOptions; }
			set
			{
				this.pacificationOptions = value;
				OnPropertyChanged(nameof(PacificationOptions));
			}
		}
	}
}