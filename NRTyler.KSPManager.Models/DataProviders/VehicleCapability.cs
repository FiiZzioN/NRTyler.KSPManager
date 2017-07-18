// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders
{
	/// <summary>
	/// Holds information containing what a <see cref="LaunchVehicle"/> can lift and where it can place it's <see cref="Payload"/>.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class VehicleCapability : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VehicleCapability"/> class.
		/// </summary>
		public VehicleCapability()
		{
			PayloadRange = new PayloadRange();
			if (Trajectory == null) Trajectory = new Trajectory();
		}

		public VehicleCapability(string trajectoryName) : this()
		{
			Trajectory = new Trajectory(trajectoryName);
		}

		private PayloadRange payloadRange;
		private Trajectory trajectory;

		/// <summary>
		/// Gets or sets the payload weight range.
		/// </summary>
		public PayloadRange PayloadRange
		{
			get { return this.payloadRange; }
			set
			{
				this.payloadRange = value;
				OnPropertyChanged(nameof(this.PayloadRange));
			}
		}

		/// <summary>
		/// Gets or sets the trajectory parameters.
		/// </summary>
		public Trajectory Trajectory
		{
			get { return this.trajectory; }
			set
			{
				this.trajectory = value;
				OnPropertyChanged(nameof(this.Trajectory));
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