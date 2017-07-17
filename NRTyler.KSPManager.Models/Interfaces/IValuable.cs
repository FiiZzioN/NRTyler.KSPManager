// ***********************************************************************
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

namespace NRTyler.KSPManager.Models.Interfaces
{
	/// <summary>
	/// Applies to <see cref="object"/>'s that have value, such as vehicles and options stages.
	/// </summary>
	public interface IValuable
	{
		/// <summary>
		/// Gets or sets the price of an object.
		/// </summary>
		decimal? Price { get; set; }
	}
}