// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-14-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders
{
	/// <summary>
	/// Holds the various types of trajectories that a vehicle is capable of reaching.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class VehicleCapability : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VehicleCapability"/> class.
		/// </summary>
		public VehicleCapability()
		{
			this.capableTrajectories = new Dictionary<string, Trajectory>();
		}

		private Dictionary<string, Trajectory> capableTrajectories;

		/// <summary>
		/// Gets or sets the trajectories that the specified vehicle is capable of reaching.
		/// </summary>
		public Dictionary<string, Trajectory> CapableTrajectories
		{
			get
			{
				if (this.capableTrajectories != null) return this.capableTrajectories;

				this.capableTrajectories = new Dictionary<string, Trajectory>();
				return this.capableTrajectories;
			}
			set
			{
				this.capableTrajectories = value;
				OnPropertyChanged(nameof(CapableTrajectories));
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