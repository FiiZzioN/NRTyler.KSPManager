/*
// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.IO;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Services.Interfaces
{
	public interface IRepository<out T>
	{

		/// <summary>
		/// Serializes the object to an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		void Serialize(Stream stream, [NotNull] object obj);

		/// <summary>
		/// Deserializes an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		T Deserialize(Stream stream);
	}
}
*/