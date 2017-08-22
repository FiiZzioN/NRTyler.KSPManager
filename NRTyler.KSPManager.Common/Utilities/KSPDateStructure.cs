// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Common
//
// Author           : TriggerAu
// Created          : 08-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-23-2014
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NRTyler.KSPManager.Common.Utilities
{
    /// <summary>
    /// Static class to control the Calendar used by KSPDateTime and KSPTimeSpan
    /// </summary>
    public static class KSPDateStructure
    {
        /// <summary>What Day does UT 0 represent</summary>
	    public static int EpochDayOfYear { get; private set; }

	    /// <summary>What Year does UT 0 represent</summary>
	    public static int EpochYear { get; private set; }

	    /// <summary>How many seconds (game UT) make up a minute</summary>
	    public static int SecondsPerMinute { get; private set; }

	    /// <summary>How many minutes make up an hour</summary>
	    public static int MinutesPerHour { get; private set; }

	    /// <summary>How many hours make up a day</summary>
	    public static int HoursPerDay { get; private set; }

	    /// <summary>How many days make up a year</summary>
	    public static int DaysPerYear { get; private set; }

	    /// <summary>How many seconds (game UT) make up an hour</summary>
	    public static int SecondsPerHour
	    {
		    get { return SecondsPerMinute * MinutesPerHour; }
	    }

	    /// <summary>How many seconds (game UT) make up a day</summary>
	    public static int SecondsPerDay
	    {
		    get { return SecondsPerHour * HoursPerDay; }
	    }

	    /// <summary>How many seconds (game UT) make up a year - not relevant for Earth time</summary>
	    public static int SecondsPerYear
	    {
		    get { return SecondsPerDay * DaysPerYear; }
	    }

	    /// <summary>What Earth date does UT 0 represent</summary>
	    public static DateTime CustomEpochEarth { get; private set; }

	    /// <summary>What type of Calendar is being used - KSPStock, Earth, or custom</summary>
	    public static CalendarTypeEnum CalendarType { get; private set; }

	    /// <summary>Sets the Date Structure to be stock KSP</summary>
	    public static void SetKSPStockCalendar()
        {
            CalendarType = CalendarTypeEnum.KSPStock;

            EpochYear = 1;
            EpochDayOfYear = 1;
            SecondsPerMinute = 60;
            MinutesPerHour = 60;

			//? ---------------- FIX ME ---------------- dsfaf
			//HoursPerDay = GameSettings.KERBIN_TIME ? 6 : 24;
			//DaysPerYear = GameSettings.KERBIN_TIME ? 426 : 365;

			HoursPerDay = true ? 6 : 24;
	        DaysPerYear = true ? 426 : 365;
		}

        /// <summary>Sets the Date Structure to be Earth based - Epoch of 1/1/1951 (RSS default)</summary>
	    public static void SetEarthCalendar()
	    {
		    SetEarthCalendar(1951, 1, 1);
	    }

	    /// <summary>Sets the Date Structure to be Earth based - With an epoch date supplied</summary>
	    /// <param name="epochyear">year represented by UT0</param>
	    /// <param name="epochmonth">month represented by UT0</param>
	    /// <param name="epochday">day represented by UT0</param>
	    public static void SetEarthCalendar(Int32 epochyear, Int32 epochmonth, Int32 epochday)
	    {
		    CalendarType = CalendarTypeEnum.Earth;

		    CustomEpochEarth = new DateTime(epochyear, epochmonth, epochday);

		    EpochYear = epochyear;
		    EpochDayOfYear = CustomEpochEarth.DayOfYear;
		    SecondsPerMinute = 60;
		    MinutesPerHour = 60;

		    HoursPerDay = 24;
		    DaysPerYear = 365;
	    }

	    /// <summary>Set Calendar type to be a custom type</summary>
	    public static void SetCustomCalendar()
	    {
		    SetKSPStockCalendar();
		    CalendarType = CalendarTypeEnum.Custom;
	    }

	    /// <summary>Set Calendar type be a custom type with the supplied values</summary>
	    /// <param name="CustomEpochYear">Year represented by UT 0</param>
	    /// <param name="CustomEpochDayOfYear">DayOfYear represented by UT 0</param>
	    /// <param name="CustomDaysPerYear">How many days per year in this calendar</param>
	    /// <param name="CustomHoursPerDay">How many hours per day  in this calendar</param>
	    /// <param name="CustomMinutesPerHour">How many minutes per hour in this calendar</param>
	    /// <param name="CustomSecondsPerMinute">How many seconds per minute in this calendar</param>
	    public static void SetCustomCalendar(int CustomEpochYear, int CustomEpochDayOfYear, int CustomDaysPerYear, int CustomHoursPerDay, int CustomMinutesPerHour, int CustomSecondsPerMinute)
	    {
		    CalendarType = CalendarTypeEnum.Custom;

		    EpochYear = CustomEpochYear;
		    EpochDayOfYear = CustomEpochDayOfYear;
		    SecondsPerMinute = CustomSecondsPerMinute;
		    MinutesPerHour = CustomMinutesPerHour;
		    HoursPerDay = CustomHoursPerDay;
		    DaysPerYear = CustomDaysPerYear;
	    }

	    /// <summary>Default Constructor</summary>
	    static KSPDateStructure()
	    {
		    SetKSPStockCalendar();

		    Months = new List<KSPMonth>();
		    //LeapDays = new List<KSPLeapDay>();
	    }

	    /// <summary>List of KSPMonth objects representing the months in the year</summary>
	    public static List<KSPMonth> Months { get; set; }

	    /// <summary>How many months have been defined</summary>
	    public static int MonthCount
	    {
		    get { return Months.Count; }
	    }

	    //static public List<KSPLeapDay> LeapDays { get; set; }
	    //static public Int32 LeapDaysCount { get { return LeapDays.Count; } }
    }

    /// <summary>
    /// options for KSPDateStructure Calendar Type
    /// </summary>
    public enum CalendarTypeEnum
    {
        [Description("KSP Stock Calendar")]
		KSPStock = 0,
        [Description("Earth Calendar")]
		Earth = 1,
        [Description("Custom Calendar")]
		Custom = 2,
    }

    /// <summary>
    /// Definition of a calendar month
    /// </summary>
    public class KSPMonth
    {
        public KSPMonth(string name, int days) { this.Name = name; this.Days = days; }

        /// <summary>
        /// Name of the month
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How many days in this month
        /// </summary>
        public int Days { get; set; }
    }
}
