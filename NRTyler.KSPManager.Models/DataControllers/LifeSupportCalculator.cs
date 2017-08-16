// ***********************************************************************
// Assembly         : NRTyler.KSPManager.Models
//
// Author           : Nicholas Tyler
// Created          : 08-16-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-16-2017
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
			this.CrewedVehicle        = crewedVehicle;

			var defaultLength    = BaseGameSettings.DefaultHoursInKerbinDay;
			var lengthMultiplier = crewedVehicle.BaseGameSettings.DayLengthMultiplier;

			this.DayLength            = defaultLength * lengthMultiplier;			
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
		/// Calculates how many days the life support resources will last. The value returned takes into account both the number of crew that this is supposed to support, as well as taking into consideration how long an in-game day is supposed to last. This is based of the values in the <see cref="BaseGameSettings"/>.
		/// </summary>
		/// <param name="unitsPerDay">The number of units used per day.</param>
		/// <param name="totalUnitsStored">The total amount of units stored in the vehicle.</param>
		/// <returns>System.Double.</returns>
		public double CalculateLifeSupportResources(double unitsPerDay, double totalUnitsStored)
		{
			var numberOfKerbals     = this.CrewedVehicle.NumberOfCrew;
			var adjustedUnitsPerDay = (unitsPerDay * numberOfKerbals) * (this.DayLength / BaseGameSettings.DefaultHoursInKerbinDay);

			
			return totalUnitsStored / adjustedUnitsPerDay;
		}

		/// <summary>
		/// Calculates how many days the electricity will last. The value returned takes into account both the number of crew that this is supposed to support, as well as taking into consideration how long an in-game day is supposed to last. This is based off of the values in the <see cref="BaseGameSettings"/>.
		/// </summary>
		/// <param name="vehicle">The <see cref="ICrewable"/> vehicle that needs its electrical system analyzed.</param>
		/// <returns>System.Double.</returns>
		public double CalculateElectricity(ICrewable vehicle)
		{
			// Set fields to their respective data point for easier readability in the formula below.
			var numberOfKerbals   = vehicle.NumberOfCrew;
			var baseUnitsPerDay   = vehicle.LifeSupportSettings.BaseElectricityPerDay;
			var kerbalUnitsPerDay = vehicle.LifeSupportSettings.KerbalElectricityPerDay;
			var totalUnitsStored  = vehicle.LifeSupportSystem.ProvisionsStorage.TotalElectricityStored;

			var totalUnitsPerDay = (baseUnitsPerDay + (kerbalUnitsPerDay * numberOfKerbals)) * (this.DayLength / BaseGameSettings.DefaultHoursInKerbinDay);

			return CalculateLifeSupportResources(totalUnitsPerDay, totalUnitsStored);
		}

		/// <summary>
		/// Calculates how many days the electricity will last. The value returned takes into account both the number of crew that this is supposed to support, as well as taking into consideration how long an in-game day is supposed to last. This is based off of the values in the <see cref="BaseGameSettings"/>.
		/// </summary>
		/// <param name="baseUnitsPerDay">The number of units the vehicle will use per day.</param>
		/// <param name="kerbalUnitsPerDay">The number of units a single kerbal will use per day.</param>
		/// <param name="totalUnitsStored">The total amount of units stored in the vehicle.</param>
		/// <returns>System.Double.</returns>
		public double CalculateElectricity(double baseUnitsPerDay, double kerbalUnitsPerDay, double totalUnitsStored)
		{
			var numberOfKerbals  = this.CrewedVehicle.NumberOfCrew;
			var totalUnitsPerDay = (baseUnitsPerDay + (kerbalUnitsPerDay * numberOfKerbals)) * (this.DayLength / BaseGameSettings.DefaultHoursInKerbinDay);

			return CalculateLifeSupportResources(totalUnitsPerDay, totalUnitsStored);
		}
	}
}