// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ServiceTests
//
// Author           : Nicholas Tyler
// Created          : 09-07-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-07-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Models.DataProviders.Settings;

namespace NRTyler.KSPManager.ServiceTests
{
    public static class RepoTestAid
    {
        /// <summary>
        /// Gets the default file name.
        /// </summary>
        public static string FileName { get; } = "Default.veh";

        /// <summary>
        /// Gets the application settings.
        /// </summary>
        public static ApplicationSettings AppSettings { get; } = new ApplicationSettings();

        /// <summary>
        /// Returns the vehicle file location plus the default vehicle file name.
        /// </summary>
        /// <returns>The path.</returns>
        public static string VehiclePathDefault()
        {
            return $"{AppSettings.VehicleFileLocation}/{FileName}";
        }

        /// <summary>
        /// Returns the vehicle file location plus a customized file name.
        /// </summary>
        /// <returns>The path.</returns>
        public static string VehiclePathPlusName(string name)
        {
            return $"{AppSettings.VehicleFileLocation}/{name}.veh";
        }
    }
}