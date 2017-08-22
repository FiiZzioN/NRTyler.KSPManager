// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 08-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-22-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.IO;
using System.Xml.Serialization;
using NRTyler.CodeLibrary.Interfaces.Generic;
using NRTyler.KSPManager.Models.Annotations;

namespace NRTyler.KSPManager.Services.Repositories
{
	public class VehicleRepository<T> : IRepository<T>
	{
		/// <summary>
		/// Serializes the object to an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		/// <exception cref="ArgumentNullException">obj - The object being serialized can not be null!</exception>
		public void Serialize(Stream stream, [NotNull] T obj)
		{
			// stream example: File.Open(fileName, FileMode.Create);

			if (obj == null) throw new ArgumentNullException(nameof(obj), "The object being serialized can not be null!");

			var formatter = new XmlSerializer(typeof(T));

			using (stream)
			{
				formatter.Serialize(stream, obj);
			}
		}

		/// <summary>
		/// Deserializes an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		public T Deserialize(Stream stream)
		{
			// stream example: File.Open(fileName, FileMode.Open);

			var formatter = new XmlSerializer(typeof(T));

			using (stream)
			{
				return (T)formatter.Deserialize(stream);
			}
		}
	}
}