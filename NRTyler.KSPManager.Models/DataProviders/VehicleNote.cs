﻿// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-17-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.KSPManager.Models.Annotations;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.Models.DataProviders
{
	public class VehicleNote : INotifyPropertyChanged
	{
		public VehicleNote()
		{
			Title = null;
		}

		public VehicleNote(string title)
		{
			Title = title;
		}

		private string title;
		private string noteField;

		public string Title
		{
			get { return this.title; }
			set
			{
				StringAssistant.TitleInsurance(value, ref this.title);
				OnPropertyChanged(nameof(Title));
			}
		}


		public string Content
		{
			get { return this.noteField; }
			set
			{
				this.noteField = value;
				OnPropertyChanged(nameof(this.Content));
			}
		}

		#region Overrides of Object

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			var oldString = $"Title: {this.Title}@Content: {this.Content}";
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