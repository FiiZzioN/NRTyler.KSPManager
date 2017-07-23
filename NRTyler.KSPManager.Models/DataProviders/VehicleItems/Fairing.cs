// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-20-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleItems
{
	/// <summary>
	/// Holds information about a given <see cref="Fairing"/> that a <see cref="INotifyPropertyChanged"/> has at its disposal.
	/// </summary>
	/// <seealso cref="System.ComponentModel" />
	public class Fairing : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Fairing"/> class.
		/// </summary>
		public Fairing()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fairing"/> class.
		/// </summary>
		/// <param name="length">The length of the fairing.</param>
		public Fairing(decimal? length)
		{
			this.Length = length;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fairing"/> class.
		/// </summary>
		/// <param name="length">The length of the fairing.</param>
		/// <param name="diameter">The diameter of the fairing.</param>
		public Fairing(decimal? length, decimal? diameter)
		{
			this.Length = length;
			this.Diameter = diameter;
		}

		private decimal? length;
		private decimal? diameter;

		/// <summary>
		/// Gets or sets the length of the fairing.
		/// </summary>
		public decimal? Length
		{
			get { return this.length; }
			set
			{
				if (value < 0) return;

				this.length = value;
				OnPropertyChanged(nameof(this.Length));
			}
		}

		/// <summary>
		/// Gets or sets the diameter of the fairing.
		/// </summary>
		public decimal? Diameter
		{
			get { return this.diameter; }
			set
			{
				if (value < 0) return;

				this.diameter = value;
				OnPropertyChanged(nameof(this.Diameter));
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