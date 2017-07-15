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
	/// Holds a collection of pacification options that a vehicle has available for use.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class PacificationCollection : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PacificationCollection"/> class.
		/// </summary>
		public PacificationCollection()
		{
			this.options = new Dictionary<string, PacificationOption>();
		}

		private Dictionary<string, PacificationOption> options;

		/// <summary>
		/// Gets or sets the pacification options that a vehicle has available for use.
		/// </summary>
		public Dictionary<string, PacificationOption> Options
		{
			get
			{
				if (this.options != null) return this.options;

				this.options = new Dictionary<string, PacificationOption>();
				return this.options;
			}
			set
			{
				this.options = value;
				OnPropertyChanged(nameof(this.Options));
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