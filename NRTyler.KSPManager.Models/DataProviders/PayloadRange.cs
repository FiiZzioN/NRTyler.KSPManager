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

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Models.DataProviders
{
	/// <summary>
	/// <see cref="PayloadRange"/> holds the smallest and largest weight values that a vehicle can safely lift.
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
		/// <param name="smallest">The smallest.</param>
		/// <param name="largest">The largest.</param>
		public PayloadRange(int smallest, int largest)
		{
			Smallest = smallest;
			Largest = largest;

			EnsureProperAssignment();
		}

		private int smallest;
		private int largest;

		/// <summary>
		/// Gets or sets the weight of the smallest payload.
		/// </summary>
		public int Smallest
		{
			get { return this.smallest; }
			set
			{
				if (value < 0) return;

				this.smallest = value;
				OnPropertyChanged(nameof(this.Smallest));
			}
		}

		/// <summary>
		/// Gets or sets the weight of the largest payload.
		/// </summary>
		public int Largest
		{
			get { return this.largest; }
			set
			{
				if (value < 0) return;

				this.largest = value;
				OnPropertyChanged(nameof(this.Largest));
			}
		}

		/// <summary>
		/// Ensures that the weight values are assigned to the proper fields.
		/// </summary>
		private void EnsureProperAssignment()
		{
			var smaller = this.smallest;
			var larger = this.largest;

			if (this.smallest < this.largest) return;

			this.smallest = larger;
			this.largest = smaller;
		}

		#region Overrides of Object

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			var oldString = $"Smallest: {Smallest}@Largest: {Largest}";
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