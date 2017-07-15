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
using NRTyler.KSPManager.Models.DataProviders;

namespace NRTyler.KSPManager.Models.DataCollections
{
	/// <summary>
	/// Holds a collection of trajectories that a vehicle can reach.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class TrajectoryCollection : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TrajectoryCollection"/> class.
		/// </summary>
		public TrajectoryCollection()
		{
			this.trajectories = new Dictionary<string, Trajectory>();
		}

		private Dictionary<string, Trajectory> trajectories;

		/// <summary>
		/// Gets or sets the trajectories that the specified vehicle is capable of reaching.
		/// </summary>
		public Dictionary<string, Trajectory> Trajectories
		{
			get
			{
				if (this.trajectories != null) return this.trajectories;

				this.trajectories = new Dictionary<string, Trajectory>();
				return this.trajectories;
			}
			set
			{
				this.trajectories = value;
				OnPropertyChanged(nameof(this.Trajectories));
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