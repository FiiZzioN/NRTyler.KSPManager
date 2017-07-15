// ***********************************************************************
// Assembly         : UtilitiesLibrary
//
// Author           : CodeBureau
// Created          : 07-27-2015
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-14-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NRTyler.KSPManager.Services.Attributes;

namespace NRTyler.KSPManager.Services.Utilities
{
    public class StringEnum
    {
        #region Instance Methods

        /// <summary>
        /// Creates a new <see cref="StringEnum"/> instance.
        /// </summary>
        /// <param name="enumType">Enum type.</param>
        public StringEnum(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException($"Supplied type must be an Enum. Type was {enumType}");

            this.EnumType = enumType;
        }

        /// <summary>
        /// Gets the string value associated with the given enum value.
        /// </summary>
        /// <param name="valueName">Name of the enum value.</param>
        /// <returns>String Value</returns>
        public string GetStringValue(string valueName)
        {
            string stringValue = null;
            try
            {
                var enumType = (Enum)Enum.Parse(this.EnumType, valueName);
                stringValue = GetStringValue(enumType);
            }
            catch (Exception) { }//Swallow!

            return stringValue;
        }

        /// <summary>
        /// Gets the string values associated with the enum.
        /// </summary>
        /// <returns>String value array</returns>
        public List<string> GetStringValues()
        {
            var values = new List<string>();

            //Look for our string value associated with fields in this enum
            foreach (var fieldInfo in this.EnumType.GetFields())
            {
                //Check for our custom attribute
                var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (attributes != null && attributes.Length > 0)
                    values.Add(attributes[0].Value);

            }

            return values.ToList();
        }

        /// <summary>
        /// Gets the values as a 'bindable' list datasource.
        /// </summary>
        /// <returns>IList for data binding</returns>
        public IList GetListValues()
        {
            var underlyingType = Enum.GetUnderlyingType(this.EnumType);
            var values = new ArrayList();

            //Look for our string value associated with fields in this enum
            foreach (var fieldInfo in this.EnumType.GetFields())
            {
                //Check for our custom attribute
                var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (attributes != null && attributes.Length > 0)
                    values.Add(new DictionaryEntry(Convert.ChangeType(Enum.Parse(this.EnumType, fieldInfo.Name), underlyingType), attributes[0].Value));

            }

            return values;
        }

        /// <summary>
        /// Return the existence of the given string value within the enum.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <returns>Existence of the string value</returns>
        public bool IsStringDefined(string stringValue)
        {
            return Parse(this.EnumType, stringValue) != null;
        }

        /// <summary>
        /// Return the existence of the given string value within the enum.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <param name="ignoreCase">Denotes whether to conduct a case-insensitive match on the supplied string value</param>
        /// <returns>Existence of the string value</returns>
        public bool IsStringDefined(string stringValue, bool ignoreCase)
        {
            return Parse(this.EnumType, stringValue, ignoreCase) != null;
        }

        /// <summary>
        /// Gets the underlying enum type for this instance.
        /// </summary>
        /// <value></value>
        public Type EnumType { get; }

        #endregion

        #region Static Methods

        private static Hashtable _stringValues = new Hashtable();

        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>String Value associated via a <see cref="StringValueAttribute"/> attribute, or null if not found.</returns>
        public static string GetStringValue(Enum value)
        {
            string output = null;
            var type = value.GetType();

            if (_stringValues.ContainsKey(value))
            {
                var stringValueAttribute = _stringValues[value] as StringValueAttribute;
                if (stringValueAttribute != null) output = stringValueAttribute.Value;
            }
            else
            {
                //Look for our 'StringValueAttribute' in the field's custom attributes
                var fieldInfo = type.GetField(value.ToString());
                var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (attributes != null && attributes.Length > 0)
                {
                    _stringValues.Add(value, attributes[0]);
                    output = attributes[0].Value;
                }
            }
            return output;
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="stringValue">String value.</param>
        /// <param name="ignoreCase">Denotes whether to conduct a case-insensitive match on the supplied string value</param>
        /// <returns>Enum value associated with the string value, or null if not found.</returns>
        public static object Parse(Type type, string stringValue, bool ignoreCase)
        {
            object output = null;
            string enumStringValue = null;

            if (!type.IsEnum)
                throw new ArgumentException($"Supplied type must be an Enum. Type was {type}");

            //Look for our string value associated with fields in this enum
            foreach (var field in type.GetFields())
            {
                //Check for our custom attribute
                var attributes = field.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (attributes != null && attributes.Length > 0)
                {
                    enumStringValue = attributes[0].Value;
                }

                //Check for equality then select actual enum value.
                if (string.Compare(enumStringValue, stringValue, ignoreCase) == 0)
                {
                    output = Enum.Parse(type, field.Name);
                    break;
                }
            }

            return output;
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value (case sensitive).
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="stringValue">String value.</param>
        /// <returns>Enum value associated with the string value, or null if not found.</returns>
        public static object Parse(Type type, string stringValue)
        {
            return Parse(type, stringValue, false);
        }

        /// <summary>
        /// Return the existence of the given string value within the enum.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <param name="enumType">Type of enum</param>
        /// <returns>Existence of the string value</returns>
        public static bool IsStringDefined(Type enumType, string stringValue)
        {
            return Parse(enumType, stringValue) != null;
        }

        /// <summary>
        /// Return the existence of the given string value within the enum.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <param name="enumType">Type of enum</param>
        /// <param name="ignoreCase">Denotes whether to conduct a case-insensitive match on the supplied string value</param>
        /// <returns>Existence of the string value</returns>
        public static bool IsStringDefined(Type enumType, string stringValue, bool ignoreCase)
        {
            return Parse(enumType, stringValue, ignoreCase) != null;
        }

        #endregion
    }
}