// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-23-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.KSPManager.Models.DataProviders.GameSettings;
using NRTyler.KSPManager.Models.Interfaces;

namespace NRTyler.KSPManager.Models.DataControllers
{
	/// <summary>
	/// Contains methods used for calculating how long life support resources will last for a given <see cref="ICrewable"/> vehicle.
	/// </summary>
	public class LifeSupportCalculator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LifeSupportCalculator"/> class.
		/// </summary>
		/// <param name="crewedVehicle">The crewed vehicle.</param>
		public LifeSupportCalculator(ICrewable crewedVehicle)
		{
			CrewedVehicle        = crewedVehicle;

			var defaultLength    = BaseGameSettings.DefaultHoursInKerbinDay;
			var lengthMultiplier = crewedVehicle.BaseGameSettings.DayLengthMultiplier;

			DayLength            = defaultLength * lengthMultiplier;			
		}

		/// <summary>
		/// Gets the crewed vehicle.
		/// </summary>
		private ICrewable CrewedVehicle { get; }

		/// <summary>
		/// Gets the number of hours in a Kerbin day after the length modifier has been applied.
		/// </summary>
		private double DayLength { get; }


		/// <summary>
		/// Calculates how many days the life support resources will last.
		/// </summary>
		/// <param name="unitsPerDay">The number of units used or generated per day.</param>
		/// <param name="totalUnitsStored">The total amount of units stored in the vehicle.</param>
		/// <returns>System.Double.</returns>
		public double CalculateLifeSupportResources(double unitsPerDay, double totalUnitsStored)
		{
			var numberOfKerbals     = CrewedVehicle.NumberOfCrew;
			var adjustedUnitsPerDay = (unitsPerDay * numberOfKerbals) * (DayLength / 6);

			return totalUnitsStored / adjustedUnitsPerDay;
		}

		/// <summary>
		/// Calculates how many days the electricity will last.
		/// </summary>
		/// <param name="baseUnitsPerDay">The number of units the vehicle will use per day.</param>
		/// <param name="kerbalUnitsPerDay">The number of units a single kerbal will use per day.</param>
		/// <param name="totalUnitsStored">The total amount of units stored in the vehicle.</param>
		/// <returns>System.Double.</returns>
		public double CalculateElectricity(double baseUnitsPerDay, double kerbalUnitsPerDay, double totalUnitsStored)
		{
			var numberOfKerbals  = CrewedVehicle.NumberOfCrew;
			var totalUnitsPerDay = (baseUnitsPerDay + (kerbalUnitsPerDay * numberOfKerbals)) * (DayLength / 6);

			return CalculateLifeSupportResources(totalUnitsPerDay, totalUnitsStored);
		}
	}
}