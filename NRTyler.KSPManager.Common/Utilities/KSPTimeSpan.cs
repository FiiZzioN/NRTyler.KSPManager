// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Common
//
// Author           : TriggerAu
// Created          : 08-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-18-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Text.RegularExpressions;
using NRTyler.KSPManager.Common.Extensions;

namespace NRTyler.KSPManager.Common.Utilities
{
    /// <summary>Represents a time interval.</summary> 
    public class KSPTimeSpan : IFormattable
    {
		#region Constructors

		/// <summary>Initializes a new <see cref="KSPTimeSpan"/> to the specified number of seconds of Game UT</summary>
		/// <param name="ut">a time period expressed in seconds</param>
		public KSPTimeSpan(Double ut)
		{
			this.UT = ut;
		}

	    /// <summary>Initializes a new <see cref="KSPTimeSpan"/> to a specified number of hours, minutes, and seconds.</summary> 
	    /// <param name="hours">Number of hours.</param>
	    /// <param name="minutes">Number of minutes.</param>
	    /// <param name="seconds">Number of seconds.</param>
	    public KSPTimeSpan(int hours, int minutes, int seconds) 
			: this(0, hours, minutes, seconds, 0)
	    {
		    
	    }

	    /// <summary>Initializes a new <see cref="KSPTimeSpan"/> to a specified number of days, hours, minutes, and seconds.</summary> 
	    /// <param name="days">Number of days.</param>
	    /// <param name="hours">Number of hours.</param>
	    /// <param name="minutes">Number of minutes.</param>
	    /// <param name="seconds">Number of seconds.</param>
	    public KSPTimeSpan(int days, int hours, int minutes, int seconds)
		    : this(days, hours, minutes, seconds, 0)
	    {
		    
	    }

	    /// <summary>Initializes a new <see cref="KSPTimeSpan"/> to a specified number of days, hours, minutes, seconds, and milliseconds.</summary> 
	    /// <param name="days">Number of days.</param>
	    /// <param name="hours">Number of hours.</param>
	    /// <param name="minutes">Number of minutes.</param>
	    /// <param name="seconds">Number of seconds.</param>
	    /// <param name="milliseconds">Number of milliseconds.</param>
	    public KSPTimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)
	    {
		    this.UT = (days * KSPDateStructure.SecondsPerDay) +
		              (hours * KSPDateStructure.SecondsPerHour) +
		              (minutes * KSPDateStructure.SecondsPerMinute) +
		              seconds + (Double)milliseconds / 1000;
	    }

	    /// <summary>Initializes a new <see cref="KSPTimeSpan"/> to a specified number of days, hours, minutes, and seconds.</summary> 
	    /// <param name="days">Number of days.</param>
	    /// <param name="hours">Number of hours.</param>
	    /// <param name="minutes">Number of minutes.</param>
	    /// <param name="seconds">Number of seconds.</param>
	    public KSPTimeSpan(string days, string hours, string minutes, string seconds)
	    {
		    this.UT = new KSPTimeSpan(Convert(days), Convert(hours), Convert(minutes), Convert(seconds), 0).UT;

			// Simple shortcut to the method.
		    int Convert(string value)
		    {
			    return System.Convert.ToInt32(value);
		    }
	    }

		#endregion

		#region Properties

		//Shortcut to the Calendar Type
		private CalendarTypeEnum CalType
		{
			get
			{
				return KSPDateStructure.CalendarType;
			}
		}

		//Descriptors of Timespan - uses UT as the Root value
		/// <summary>Gets the years component  of the time interval represented by the current <see cref="KSPTimeSpan"/> structure</summary> 
		/// <returns>
		/// <para>Returns 0 if the <see cref="KSPDateStructure.CalendarType"/> == <see cref="CalendarTypeEnum.Earth"/></para>
		/// <para>otherwise</para>
		/// Returns the year component of this instance. The return value can be positive or negative.
		/// </returns>
		public int Years
		{
			get
			{
				if (this.CalType != CalendarTypeEnum.Earth)
				{
					return (Int32)this.UT / KSPDateStructure.SecondsPerYear;
				}

				return 0;
			}
		}

		/// <summary>
		///     Gets the days component of the time interval represented by the current <see cref="KSPTimeSpan"/>
		///     structure.
		/// </summary>
		/// <returns>
		///     <para>
		///         Returns Total Number of Days for the current component if the <see cref="KSPDateStructure.CalendarType" /> ==
		///         <see cref="CalendarTypeEnum.Earth" />
		///     </para>
		///     <para>otherwise</para>
		///     The day component of the current <see cref="KSPTimeSpan"/> structure. The return value ranges between +/-
		///     <see cref="KSPDateStructure.DaysPerYear" />
		/// </returns>
		public int Days
		{
			get
			{
				if (this.CalType != CalendarTypeEnum.Earth)
					return (Int32)this.UT / KSPDateStructure.SecondsPerDay % KSPDateStructure.DaysPerYear;

				return (Int32)this.UT / KSPDateStructure.SecondsPerDay;
			}
		}

		/// <summary>
		///     Gets the hours component of the time interval represented by the current <see cref="KSPTimeSpan"/>
		///     structure.
		/// </summary>
		/// <returns>
		///     The hour component of the current <see cref="KSPTimeSpan"/> structure. The return value ranges between
		///     +/- <see cref="KSPDateStructure.HoursPerDay" />
		/// </returns>
		public int Hours
		{
			get
			{
				return (Int32)this.UT / KSPDateStructure.SecondsPerHour % KSPDateStructure.HoursPerDay;
			}
		}

		/// <summary>
		///     Gets the minutes component of the time interval represented by the current <see cref="KSPTimeSpan"/>
		///     structure.
		/// </summary>
		/// <returns>
		///     The minute component of the current <see cref="KSPTimeSpan"/> structure. The return value ranges between +/-
		///     <see cref="KSPDateStructure.MinutesPerHour" />
		/// </returns>
		public int Minutes
		{
			get
			{
				return (Int32)this.UT / KSPDateStructure.SecondsPerMinute % KSPDateStructure.MinutesPerHour;
			}
		}

		/// <summary>
		///     Gets the seconds component of the time interval represented by the current <see cref="KSPTimeSpan"/>
		///     structure.
		/// </summary>
		/// <returns>
		///     The second component of the current <see cref="KSPTimeSpan"/> structure. The return value ranges between +/-
		///     <see cref="KSPDateStructure.SecondsPerMinute" />
		/// </returns>
		public int Seconds
		{
			get
			{
				return (Int32)this.UT % KSPDateStructure.SecondsPerMinute;
			}
		}

		/// <summary>
		///     Gets the milliseconds component of the time interval represented by the current <see cref="KSPTimeSpan"/>
		///     structure.
		/// </summary>
		/// <returns>
		///     The millisecond component of the current <see cref="KSPTimeSpan"/> structure. The return value ranges
		///     from -999 through 999.
		/// </returns>
		public int Milliseconds
		{
			get
			{
				return (int)(Math.Round(this.UT - Math.Floor(this.UT), 3) * 1000);
			}
		}

		/// <summary>Replaces the normal "Ticks" function. This is Seconds of UT</summary>
		/// <returns>The number of seconds of game UT in this instance</returns>
		public double UT { get; set; }

		#region Calculated Properties

		/// <summary>
		///     Gets the value of the current <see cref="KSPTimeSpan"/> structure expressed in whole and fractional
		///     milliseconds.
		/// </summary>
		/// <returns>The total number of milliseconds represented by this instance.</returns>
		public Double TotalMilliseconds
		{
			get
			{
				return this.UT * 1000;
			}
		}

		/// <summary>
		///     Gets the value of the current <see cref="KSPTimeSpan"/> structure expressed in whole and fractional
		///     seconds.
		/// </summary>
		/// <returns>The total number of seconds represented by this instance.</returns>
		public Double TotalSeconds
		{
			get
			{
				return this.UT;
			}
		}

		/// <summary>
		///     Gets the value of the current <see cref="KSPTimeSpan"/> structure expressed in whole and fractional
		///     minutes.
		/// </summary>
		/// <returns>The total number of minutes represented by this instance.</returns>
		public Double TotalMinutes
		{
			get
			{
				return this.UT / KSPDateStructure.SecondsPerMinute;
			}
		}

		/// <summary>
		///     Gets the value of the current <see cref="KSPTimeSpan"/> structure expressed in whole and fractional
		///     hours.
		/// </summary>
		/// <returns>The total number of hours represented by this instance.</returns>
		public Double TotalHours
		{
			get
			{
				return this.UT / KSPDateStructure.SecondsPerHour;
			}
		}

		/// <summary>Gets the value of the current <see cref="KSPTimeSpan"/> structure expressed in whole and fractional days.</summary>
		/// <returns>The total number of days represented by this instance.</returns>
		public Double TotalDays
		{
			get
			{
				return this.UT / KSPDateStructure.SecondsPerDay;
			}
		}

		#endregion

		#endregion

		#region String Formatter

		/// <summary>Generates some standard templated versions of output</summary>
		/// <param name="TimeSpanFormat">Enum of some common formats</param>
		/// <returns>A string that represents the value of this instance.</returns>
		public String ToStringStandard(TimeSpanStringFormatsEnum TimeSpanFormat)
        {
            switch (TimeSpanFormat)
            {
                case TimeSpanStringFormatsEnum.TimeAsUT:
                    String strReturn = "";
                    if (this.UT < 0) strReturn += "+ ";
                    strReturn += String.Format("{0:N0}s", Math.Abs(this.UT));
                    return strReturn;

                case TimeSpanStringFormatsEnum.KSPFormat:
                    return ToString(5);

                case TimeSpanStringFormatsEnum.IntervalLong:
                    return ToString("y Year\\s, d Da\\y\\s, hh:mm:ss");

                case TimeSpanStringFormatsEnum.IntervalLongTrimYears:
                    return ToString("y Year\\s, d Da\\y\\s, hh:mm:ss").Replace("0 Years, ","");

                case TimeSpanStringFormatsEnum.DateTimeFormat:
                    String strFormat = "";
                    if (this.Years > 0) strFormat += "y\\y";
                    if (this.Days > 0) strFormat += (strFormat.EndsWith("y") ? ", ":"") + "d\\d";
                    if (strFormat!="") strFormat += " ";
                    strFormat += "hh:mm:ss";

                    if (this.UT < 0) strFormat = "+ " + strFormat;

                    return ToString(strFormat);

                default:
                    return ToString();
            }
        }

        /// <summary>Returns the string representation of the value of this instance.</summary> 
        /// <returns>A string that represents the value of this instance.</returns>
        public override String ToString()
        {
            return ToString(1);
        }

        /// <summary>Returns the string representation of the value of this instance.</summary> 
        /// <param name="Precision">How many parts of the timespan to return (of year, Day, hour, minute, second)</param>
        /// <returns>A string that represents the value of this instance.</returns>
        public String ToString(Int32 Precision)
        {
            Int32 Displayed = 0;
            String format = "";

            if (this.UT < 0) format += "+";


            if (this.CalType != CalendarTypeEnum.Earth)
			{
                if ((Years > 0 || Precision > 4) && Displayed < Precision)
				{
                    format   = "y\\y,";
                    Displayed++;
                }
            }

            if((Days > 0 || Precision > 3) && Displayed<Precision)
			{
                format   = "d\\d,";
                Displayed++;
            }

            if ((Hours > 0 || Precision > 2) && Displayed<Precision)
			{
                format   += (format==""?"":" ") + "h\\h,";
                Displayed++;
            }

            if ((Minutes > 0 || Precision > 1) && Displayed<Precision)
			{
                format   += (format==""?"":" ") + "m\\m,";
                Displayed++;
            }

            if ((Seconds > 0 || Precision > 0) && Displayed<Precision)
			{
                format   += (format==""?"":" ") + "s\\s,";
                Displayed++;
            }

            format = format.TrimEnd(',');

            return ToString(format, null);
        }

        /// <summary>Returns the string representation of the value of this instance.</summary> 
        /// <param name="format">Format string using the usual characters to interpret custom datetime - as per standard Timespan custom formats</param>
        /// <returns>A string that represents the value of this instance.</returns>
        public String ToString(String format)
        {
            return ToString(format, null);
        }

	    /// <summary>Returns the string representation of the value of this instance.</summary> 
	    /// <param name="format">Format string using the usual characters to interpret custom datetime - as per standard Timespan custom formats</param>
	    /// <param name="provider">Should be null in almost all cases.</param>
	    /// <returns>A string that represents the value of this instance.</returns>
	    public String ToString(String format, IFormatProvider provider)
        {
            //parse and replace the format stuff
            var matches = Regex.Matches(format, "([a-zA-z])\\1{0,}");

            for (var i = matches.Count - 1; i >= 0; i--)
            {
                var m       = matches[i];
                var mIndex  = m.Index;
	            var mLength = m.Length;

	            if (mIndex > 0 && format[m.Index - 1] == '\\')
                {
                    if (m.Length == 1)
                        continue;
                    else
                    {
                        mIndex++;
                        mLength--;
                    }
                }
                switch (m.Value[0])
                {
                    case 'y':
                        format = format.Substring(0, mIndex) + 
							      Years.ToString("D" + mLength) + 
								 format.Substring(mIndex + mLength);
                        break;

                    case 'd':
                        format = format.Substring(0, mIndex) + 
							       Days.ToString("D" + mLength) + 
								 format.Substring(mIndex + mLength);
                        break;

                    case 'h':
	                    var hpdLength = KSPDateStructure.HoursPerDay.ToString().Length;

						format = format.Substring(0, mIndex) + 
							      Hours.ToString("D" + mLength.Clamp(1, hpdLength)) + 
								 format.Substring(mIndex + mLength);
                        break;

                    case 'm':
	                    var mphLength = KSPDateStructure.MinutesPerHour.ToString().Length;

						format = format.Substring(0, mIndex) + 
							    Minutes.ToString("D" + mLength.Clamp(1, mphLength)) + 
								 format.Substring(mIndex + mLength);
                        break;

                    case 's':
	                    var spmLength = KSPDateStructure.SecondsPerMinute.ToString().Length;

						format = format.Substring(0, mIndex) + 
							    Seconds.ToString("D" + mLength.Clamp(1, spmLength)) + 
							     format.Substring(mIndex + mLength);
                        break;

                    default:
                        break;
                }
            }

            //Now strip out the \ , but not multiple \\
            format = Regex.Replace(format, "\\\\(?=[a-z])", "");

            return format;
        }

		#endregion

		#region Instance Methods

		#region Mathematic Methods

		/// <summary>Returns a new <see cref="KSPTimeSpan"/> object whose value is the sum of the specified <see cref="KSPTimeSpan"/> object and this instance.</summary> 
		/// <param name="value">A <see cref="KSPTimeSpan"/>.</param>
		/// <returns>A new object that represents the value of this instance plus the value of the timespan supplied.</returns>
		public KSPTimeSpan Add(KSPTimeSpan value)
		{
            return new KSPTimeSpan(UT + value.UT);
        }

		/// <summary>Returns a new <see cref="KSPTimeSpan"/> object whose value is the absolute value of the current <see cref="KSPTimeSpan"/> object.</summary> 
		/// <returns>A new object whose value is the absolute value of the current <see cref="KSPTimeSpan"/> object.</returns>
		public KSPTimeSpan Duration()
		{
            return new KSPTimeSpan(Math.Abs(UT));
        }

        /// <summary>Returns a new <see cref="KSPTimeSpan"/> object whose value is the negated value of this instance.</summary> 
        /// <returns>A new object with the same numeric value as this instance, but with the opposite sign.</returns>
        public KSPTimeSpan Negate()
		{
            return new KSPTimeSpan(UT * -1);
        }

        #endregion

        #region Comparison Methods

        /// <summary>Compares this instance to a specified <see cref="KSPTimeSpan"/> object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the <see cref="KSPTimeSpan"/> object.</summary> 
        /// <param name="value">A <see cref="KSPTimeSpan"/> object to compare to this instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.Value Description A negative integer This instance is shorter than value. Zero This instance is equal to value. A positive integer This instance is longer than value.</returns>
        public int CompareTo(KSPTimeSpan value)
		{
            return Compare(this, value);
        }

        /// <summary>Value Condition -1 This instance is shorter than value. 0 This instance is equal to value. 1 This instance is longer than value.-or- value is null.</summary> 
        /// <param name="value">An object to compare, or null.</param>
        /// <returns>Value Condition -1 This instance is shorter than value. 0 This instance is equal to value. 1 This instance is longer than value.-or- value is null.</returns>
        public int CompareTo(object value)
		{
            if (value == null) return 1;

            return CompareTo((KSPTimeSpan)value);
        }

        /// <summary>Returns a value indicating whether this instance is equal to a specified <see cref="KSPTimeSpan"/> object.</summary> 
        /// <param name="value">An <see cref="KSPTimeSpan"/> object to compare with this instance.</param>
        /// <returns>true if obj represents the same time interval as this instance; otherwise, false.</returns>
        public bool Equals(KSPTimeSpan value)
		{
            return Equals(this, value);
        }

        /// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary> 
        /// <param name="value">An object to compare with this instance</param>
        /// <returns>true if value is a <see cref="KSPTimeSpan"/> object that represents the same time interval as the current <see cref="KSPTimeSpan"/> structure; otherwise, false.</returns>
        public override bool Equals(object value)
		{
            return (value?.GetType() == GetType()) && Equals((KSPTimeSpan)value);
        }
        #endregion        
        

        /// <summary>Returns a hash code for this instance.</summary> 
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.UT.GetHashCode();
        }

        #endregion


        #region Static Methods

        /// <summary>Compares two <see cref="KSPTimeSpan"/> values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A <see cref="KSPTimeSpan"/>.</param>
        /// <returns>Value Condition -1 t1 is shorter than t20 t1 is equal to t21 t1 is longer than t2</returns>
        public static int Compare(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            if (t1.UT < t2.UT)
                return -1;

            if (t1.UT > t2.UT)
                return 1;
            
            return 0;
        }

        /// <summary>Returns a value indicating whether two specified instances of <see cref="KSPTimeSpan"/> are equal.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        public static bool Equals(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return Math.Abs(t1.UT - t2.UT) < 0.00001;
        }


        /// <summary>Returns a <see cref="KSPTimeSpan"/> that represents a specified number of days, where the specification is accurate to the nearest millisecond.</summary> 
        /// <param name="value">A number of days, accurate to the nearest millisecond.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> that represents value.</returns>
        public static KSPTimeSpan FromDays(Double value) {
            return new KSPTimeSpan(value * KSPDateStructure.SecondsPerDay);
        }

        /// <summary>Returns a <see cref="KSPTimeSpan"/> that represents a specified number of hours, where the specification is accurate to the nearest millisecond.</summary> 
        /// <param name="value">A number of hours, accurate to the nearest millisecond.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> that represents value.</returns>
        public static KSPTimeSpan FromHours(Double value)
        {
            return new KSPTimeSpan(value * KSPDateStructure.SecondsPerHour);
        }

        /// <summary>Returns a <see cref="KSPTimeSpan"/> that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.</summary> 
        /// <param name="value">A number of minutes, accurate to the nearest millisecond.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> that represents value.</returns>
        public static KSPTimeSpan FromMinutes(Double value)
        {
            return new KSPTimeSpan(value * KSPDateStructure.SecondsPerMinute);
        }

        /// <summary>Returns a <see cref="KSPTimeSpan"/> that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.</summary> 
        /// <param name="value">A number of seconds, accurate to the nearest millisecond.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> that represents value.</returns>
        public static KSPTimeSpan FromSeconds(Double value)
        {
            return new KSPTimeSpan(value);
        }

        /// <summary>Returns a <see cref="KSPTimeSpan"/> that represents a specified number of milliseconds.</summary> 
        /// <param name="value">A number of milliseconds.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> that represents value.</returns>
        public static KSPTimeSpan FromMilliseconds(Double value)
        {
            return new KSPTimeSpan(value / 1000);
        }

        #endregion


        #region Operators

        /// <summary>Subtracts a specified <see cref="KSPTimeSpan"/> from another specified <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t1"> A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2"> A TimeSpan.</param>
        /// <returns>A TimeSpan whose value is the result of the value of t1 minus the value of t2.</returns>
        public static KSPTimeSpan operator -(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return new KSPTimeSpan(t1.UT - t2.UT);
        }

        /// <summary>Returns a <see cref="KSPTimeSpan"/> whose value is the negated value of the specified instance.</summary> 
        /// <param name="t">A <see cref="KSPTimeSpan"/>.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> with the same numeric value as this instance, but the opposite sign.</returns>
        public static KSPTimeSpan operator -(KSPTimeSpan t)
        {
            return new KSPTimeSpan(t.UT).Negate();
        }

        /// <summary>Adds two specified <see cref="KSPTimeSpan"/> instances.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A <see cref="KSPTimeSpan"/>.</param>
        /// <returns>A <see cref="KSPTimeSpan"/> whose value is the sum of the values of t1 and t2.</returns>
        public static KSPTimeSpan operator +(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return new KSPTimeSpan(t1.UT + t2.UT);
        }

        /// <summary>Returns the specified instance of <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t">A <see cref="KSPTimeSpan"/>.</param>
        /// <returns>Returns t.</returns>
        public static KSPTimeSpan operator +(KSPTimeSpan t)
        {
            return new KSPTimeSpan(t.UT);
        }

        /// <summary>Indicates whether two <see cref="KSPTimeSpan"/> instances are not equal.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the values of t1 and t2 are not equal; otherwise, false.</returns>
        public static Boolean operator !=(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return !(t1 == t2);
        }

        /// <summary>Indicates whether two <see cref="KSPTimeSpan"/> instances are equal.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        public static Boolean operator ==(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return t1.UT == t2.UT;
        }

        /// <summary>Indicates whether a specified <see cref="KSPTimeSpan"/> is less than another specified <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the value of t1 is less than the value of t2; otherwise, false.</returns>
        public static Boolean operator <=(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        /// <summary>Indicates whether a specified <see cref="KSPTimeSpan"/> is less than or equal to another specified <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the value of t1 is less than or equal to the value of t2; otherwise, false.</returns>
        public static Boolean operator <(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return t1.CompareTo(t2) < 0;
        }

        /// <summary>Indicates whether a specified <see cref="KSPTimeSpan"/> is greater than or equal to another specified <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the value of t1 is greater than or equal to the value of t2; otherwise, false.</returns>
        public static Boolean operator >=(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        /// <summary>Indicates whether a specified <see cref="KSPTimeSpan"/> is greater than another specified <see cref="KSPTimeSpan"/>.</summary> 
        /// <param name="t1">A <see cref="KSPTimeSpan"/>.</param>
        /// <param name="t2">A TimeSpan.</param>
        /// <returns>true if the value of t1 is greater than the value of t2; otherwise, false.</returns>
        public static Boolean operator >(KSPTimeSpan t1, KSPTimeSpan t2)
        {
            return t1.CompareTo(t2) > 0;
        }
        #endregion
    }

    /// <summary>
    /// Enum of standardized outputs for Timespans as strings
    /// </summary>
    public enum TimeSpanStringFormatsEnum
    {
        TimeAsUT,
        KSPFormat,
        IntervalLong,
        IntervalLongTrimYears,
        DateTimeFormat
    }
}
