﻿// ***********************************************************************
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
	public class TrajectoryParameters : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TrajectoryParameters"/> class.
		/// </summary>
		public TrajectoryParameters()
		{
			Console.WriteLine(this);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrajectoryParameters"/> class.
		/// </summary>
		/// <param name="apoapsis">The trajectory's targeted apoapsis.</param>
		/// <param name="periapsis">The trajectory's targeted periapsis.</param>
		/// <param name="inclination">The trajectory's targeted inclination.</param>
		public TrajectoryParameters(double apoapsis, double periapsis, double inclination)
		{
			Apoapsis = apoapsis;
			Periapsis = periapsis;
			Inclination = inclination;

			EnsureProperAssignment();
			Console.WriteLine(this);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrajectoryParameters"/> class.
		/// </summary>
		/// <param name="apoapsis">The trajectory's targeted apoapsis.</param>
		/// <param name="periapsis">The trajectory's targeted periapsis.</param>
		/// <param name="inclination">The trajectory's targeted inclination.</param>
		/// <param name="requiredDeltaV">The required amount of delta v need to reach the targeted trajectory.</param>
		public TrajectoryParameters(double apoapsis, double periapsis, double inclination, double requiredDeltaV)
		{
			Apoapsis = apoapsis;
			Periapsis = periapsis;
			Inclination = inclination;
			RequiredDeltaV = requiredDeltaV;

			EnsureProperAssignment();
			Console.WriteLine(this);
		}

		private double apoapsis;
		private double periapsis;
		private double inclination;
		private double requiredDeltaV;

		/// <summary>
		/// Gets or sets the targeted apoapsis.
		/// </summary>
		public double Apoapsis
		{
			get { return this.apoapsis; }
			set
			{
				if (value < 0) return;
				//if (value < this.Periapsis) return;

				this.apoapsis = value;
				EnsureProperAssignment();
				OnPropertyChanged(nameof(Apoapsis));
			}
		}

		/// <summary>
		/// Gets or sets the targeted periapsis.
		/// </summary>
		public double Periapsis
		{
			get { return this.periapsis; }
			set
			{
				if (value < 0) return;
				//if (value > this.Apoapsis) return;

				this.periapsis = value;
				EnsureProperAssignment();
				OnPropertyChanged(nameof(Periapsis));
			}
		}

		/// <summary>
		/// Gets or sets the targeted inclination.
		/// </summary>
		public double Inclination
		{
			get { return this.inclination; }
			set
			{
				if (value > 180.0) return;
				if (value < -180.0) return;
				
				this.inclination = value;
				OnPropertyChanged(nameof(Inclination));
			}
		}

		/// <summary>
		/// Gets or sets the required amount of delta v to reach the targeted trajectory.
		/// </summary>
		public double RequiredDeltaV
		{
			get { return this.requiredDeltaV; }
			set
			{
				if (value < 0) return;

				this.requiredDeltaV = value;
				OnPropertyChanged(nameof(RequiredDeltaV));
			}
		}

		/// <summary>
		/// Ensures that the altitude values are assigned to the proper fields.
		/// </summary>
		private void EnsureProperAssignment()
		{
			var smaller = this.periapsis;
			var larger = this.apoapsis;

			if (this.periapsis < this.apoapsis) return;

			this.periapsis = larger;
			this.apoapsis = smaller;
		}

		#region Overrides of Object

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			var oldString = $"Apoapsis: {Apoapsis}@Periapsis: {Periapsis}@Inclination: {Inclination}@Required DeltaV: {RequiredDeltaV}";
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
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}