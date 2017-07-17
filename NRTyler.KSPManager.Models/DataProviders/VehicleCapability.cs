// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders
{
	public class VehicleCapability : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VehicleCapability"/> class.
		/// </summary>
		public VehicleCapability()
		{
			
		}

		private PayloadRange payloadRange;
		private Trajectory trajectory;

		/// <summary>
		/// Gets or sets the payload weight range.
		/// </summary>
		public PayloadRange PayloadRange
		{
			get
			{
				if (this.payloadRange != null) return this.payloadRange;

				this.payloadRange = new PayloadRange();
				return this.payloadRange;
			}
			set
			{
				this.payloadRange = value;
				OnPropertyChanged(nameof(PayloadRange));
			}
		}

		/// <summary>
		/// Gets or sets the trajectory parameters.
		/// </summary>
		/// <value>The trajectory parameters.</value>
		public Trajectory Trajectory
		{
			get
			{
				if (this.trajectory != null) return this.trajectory;
				
				this.trajectory = new Trajectory();
				return this.trajectory;
			}
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