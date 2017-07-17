// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-14-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-16-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Concurrent;

namespace NRTyler.KSPManager.Models.DataCollections
{
	/// <summary>
	/// Holds a collection of pacification options that a vehicle has available for use.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class PacificationCollection : ConcurrentDictionary<string, decimal>
	{

	}
}