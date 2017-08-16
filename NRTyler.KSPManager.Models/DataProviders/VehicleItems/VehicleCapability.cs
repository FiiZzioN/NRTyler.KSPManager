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
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleItems
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
		/// <param name="payloadRange">The payload weight range.</param>
		/// <param name="trajectory">The trajectory parameters.</param>
		public VehicleCapability(PayloadRange payloadRange, Trajectory trajectory)
		{
			PayloadRange = payloadRange;
			Trajectory   = trajectory;
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
				OnPropertyChanged(nameof(PayloadRange));
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
				OnPropertyChanged(nameof(Trajectory));
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
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}