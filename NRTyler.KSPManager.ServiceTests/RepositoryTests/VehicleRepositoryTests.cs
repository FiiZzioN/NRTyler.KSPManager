// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ServiceTests
//
// Author           : Nicholas Tyler
// Created          : 09-05-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-07-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;
using NRTyler.KSPManager.Common.Enums;
using NRTyler.KSPManager.Models.DataProviders.VehicleItems;
using NRTyler.KSPManager.Models.DataProviders.VehicleTypes;
using NRTyler.KSPManager.Services.Repositories;

namespace NRTyler.KSPManager.ServiceTests.RepositoryTests
{
    [TestClass]
    public class VehicleRepositoryTests
    {
        public Vehicle CreateObject()
        {
            var vehicle    = new Vehicle("Test Vehicle");
            var repository = new VehicleRepository();
            var stream     = File.Open($"{RepoTestAid.VehiclePathDefault()}", FileMode.Create);

            #region Info Assignment

            #region Stages

            var stageOne = new Stage()
            {
                DryMass = 250,
                WetMass = 650,
                SpecificImpulse = 302
            };

            var stageTwo = new Stage()
            {
                DryMass = 500,
                WetMass = 1200,
                SpecificImpulse = 332
            };

            var stageThree = new Stage()
            {
                DryMass = 2200,
                WetMass = 7000,
                SpecificImpulse = 348
            };

            #endregion

            var note = new VehicleNote
            {
                Title = "This is a Note.",
                Content = "This is a simple note, but it's my note."
            };

            vehicle.DryMass = 30000;
            vehicle.WetMass = 200000;
            vehicle.Price   = 130500;
            vehicle.VehicleType = VehicleType.LaunchVehicle;
            vehicle.StageInfo.Add(1, stageOne);
            vehicle.StageInfo.Add(2, stageTwo);
            vehicle.StageInfo.Add(3, stageThree);
            vehicle.VehicleNotes.Add(note);
            vehicle.CalculateDeltaV();
            #endregion

            using (stream)
            {
                repository.Serialize(stream, vehicle);
            }

            return vehicle;
        }

        [TestMethod]
        public void VehicleDeserialization()
        {
            // Arrange
            var item       = CreateObject();
            var repository = new VehicleRepository();
            var streamOpen = File.Open($"{RepoTestAid.VehiclePathDefault()}", FileMode.Open);

            Vehicle deserializedObject;

            using (streamOpen)
            {
                deserializedObject = repository.Deserialize(streamOpen);
            }

            var expected = true;

            // Act
            var actual = item.CompareObject(deserializedObject);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}