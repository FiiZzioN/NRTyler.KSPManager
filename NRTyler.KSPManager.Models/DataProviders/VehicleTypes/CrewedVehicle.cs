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

using System.Collections.Generic;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleTypes
{
	public class CrewedVehicle : Vehicle, ICrewable
	{
		public CrewedVehicle()
		{
			VehicleType  = VehicleType.Undefined;
			StageInfo    = new SortedDictionary<int, Stage>();
			VehicleNotes = new List<VehicleNote>();
		}

		public CrewedVehicle(BaseGameSettings baseSettings, LifeSupportSettings supportSettings) : this()
		{
			BaseGameSettings    = baseSettings;
			LifeSupportSettings = supportSettings;
			LifeSupportSystem   = new LifeSupportSystem(this);
		}


		#region Backing Fields

		private int numberOfCrew;
		private LifeSupportSystem lifeSupportSystem;
		private BaseGameSettings baseGameSettings;
		private LifeSupportSettings lifeSupportSettings;

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
	}
}