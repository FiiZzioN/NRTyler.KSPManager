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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders.VehicleItems
{
	/// <summary>
	/// <see cref="PayloadRange"/> holds the lightest and heaviest values that a payload can be for the vehicle to safely lift.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class PayloadRange : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayloadRange"/> class.
		/// </summary>
		public PayloadRange()
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="PayloadRange"/> class.
		/// </summary>
		/// <param name="lightest">The smallest.</param>
		/// <param name="heaviest">The largest.</param>
		public PayloadRange(int lightest, int heaviest)
		{
			Lightest = lightest;
			Heaviest = heaviest;

			EnsureProperAssignment();
		}

		private int lightest;
		private int heaviest;

		/// <summary>
		/// Gets or sets the weight of the smallest payload.
		/// </summary>
		public int Lightest
		{
			get { return this.lightest; }
			set
			{
				if (value < 0) return;

				this.lightest = value;
				OnPropertyChanged(nameof(Lightest));
			}
		}

		/// <summary>
		/// Gets or sets the weight of the largest payload.
		/// </summary>
		public int Heaviest
		{
			get { return this.heaviest; }
			set
			{
				if (value < 0) return;

				this.heaviest = value;
				OnPropertyChanged(nameof(Heaviest));
			}
		}

		/// <summary>
		/// Ensures that the weight values are assigned to the proper fields.
		/// </summary>
		private void EnsureProperAssignment()
		{
			var smaller = this.lightest;
			var larger = this.heaviest;

			if (this.lightest < this.heaviest) return;

			this.lightest = larger;
			this.heaviest = smaller;
		}

		#region Overrides of Object

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			var oldString = $"Lightest: {this.Lightest}@Heaviest: {this.Heaviest}";
			var newString = oldString.Replace("@", "\n");

			return newString;
		}

		#endregion

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
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		} 

		#endregion
	}
}