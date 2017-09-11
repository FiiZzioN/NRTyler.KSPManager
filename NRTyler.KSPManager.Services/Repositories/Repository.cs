// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Services
//
// Author           : Nicholas Tyler
// Created          : 08-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-03-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using NRTyler.CodeLibrary.Interfaces.Generic;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.KSPManager.Services.Repositories
{
	/// <inheritdoc />
	/// <summary>
	/// Handles serialization and deserialization of objects. 
	/// </summary>
	/// <typeparam name="T">The type of <see cref="T:System.Object" /> you'll be working with.</typeparam>
	/// <seealso cref="T:NRTyler.CodeLibrary.Interfaces.Generic.IRepository`1" />
	public class Repository<T> : IBinaryRepository<T>
	{
	    /// <summary>
	    /// Gets the outer <see cref="Exception"/> error message.
	    /// </summary>
	    public string OuterMessage { get; protected set; } = String.Empty;

	    /// <summary>
	    /// Gets the inner <see cref="Exception"/> error message.
	    /// </summary>
	    public string InnerMessage { get; protected set; } = String.Empty;

        #region XML // Kept as reference.
        /*

        /// <summary>
		/// Gets the XML formatter that serializes and deserializes objects.
		/// </summary>
		protected virtual XmlSerializer XMLFormatter { get; } = new XmlSerializer(typeof(T));


        /// <inheritdoc />
        /// <summary>
        /// Serializes the object to an XML file using the specified stream.
        /// </summary>
        /// <param name="stream">The stream to the specified location and mode.</param>
        /// <param name="obj">The object to be serialized.</param>
        /// <exception cref="T:System.ArgumentNullException">obj - The object being serialized can not be null!</exception>
        /// <exception cref="T:System.NotSupportedException">XmlSerializer does not support dictionaries!</exception>
        public virtual void SerializeToXML(Stream stream, T obj)
		{
			// stream example: File.Open(fileName, FileMode.Create);

			if (obj == null)
				throw new ArgumentNullException(nameof(obj), "The object being serialized cannot be null!");

			if (obj.ContainsFieldOrPropertyType(typeof(IDictionary<object, object>)))
				throw new NotSupportedException("XmlSerializer does not support objects with dictionaries!");

			using (stream)
			{
				try
				{
					XMLFormatter?.Serialize(stream, obj);
				}
				catch (InvalidOperationException e)
				{
				    ErrorLog(e);
				}
			}
		}

		/// <inheritdoc />
		/// <summary>
		/// Deserializes an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		public virtual T DeserializeFromXML(Stream stream)
		{
			// stream example: File.Open(fileName, FileMode.Open);

			using (stream)
			{
				return (T)XMLFormatter?.Deserialize(stream);
			}
		}

		*/
        #endregion

        #region Binary

        /// <summary>
        /// Gets the Binary Formatter that serializes and deserializes objects.
        /// </summary>
        protected virtual BinaryFormatter BinaryFormatter { get; } = new BinaryFormatter();

        /// <summary>
        /// Serializes the object to a file in binary format using the specified stream.
        /// </summary>
        /// <param name="stream">The stream to the specified location and mode.</param>
        /// <param name="obj">The object to be serialized.</param>
        /// <exception cref="T:System.ArgumentNullException">obj - The object being serialized can not be null!</exception>
        public virtual void Serialize(Stream stream, T obj)
		{
		    // stream example: File.Open(fileName, FileMode.Create);

		    if (obj == null)
		        throw new ArgumentNullException(nameof(obj), "The object being serialized cannot be null!");

		    using (stream)
		    {
		        try
		        {
		            BinaryFormatter?.Serialize(stream, obj);
		        }
		        catch (SerializationException e)
		        {
		            ErrorLog(e);
		        }
		        catch (SecurityException e)
		        {
		            ErrorLog(e);
		        }
		    }
        }

		/// <summary>
		/// Deserializes a file saved in binary format using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		public virtual T Deserialize(Stream stream)
		{
		    var obj = default(T);

		    using (stream)
		    {
		        try
		        {
		            obj = (T)BinaryFormatter?.Deserialize(stream);
		        }
		        catch (SerializationException e)
		        {
		            ErrorLog(e);
		        }
		        catch (SecurityException e)
		        {
		            ErrorLog(e);
		        }

		        return obj;
		    }
        }

        #endregion

        protected virtual void ErrorLog(Exception exception)
	    {
	        var info     = exception.LogCompleteExceptionInfo();
	        OuterMessage = info.Item1;
	        InnerMessage = info.Item2;
        }
	}
}