// ***********************************************************************
// Assembly         : NRTyler.KSPManager.ConsoleAid
//
// Author           : Nicholas Tyler
// Created          : 07-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-13-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using NRTyler.KSPManager.Models.DataCollections;
using NRTyler.KSPManager.Models.DataProviders;
using NRTyler.KSPManager.Services.Enums;
using NRTyler.KSPManager.Services.Utilities;

namespace NRTyler.KSPManager.ConsoleAid
{
	public class Program
	{
		public static void Main()
		{
			var pacificationCollection = new PacificationCollection();
			var pacificationOption = new PacificationOption(PacificationType.GraveyardOrbit, 300);

			pacificationCollection.GetOrAdd(StringEnum.GetStringValue(pacificationOption.PacificationType), pacificationOption.RequiredDeltaV);

			foreach (var option in pacificationCollection)
			{
				var message = $"Type: {option.Key}@DeltaV: {option.Value} m/s";
				var newMessage = message.Replace("@", "\n");

				Console.WriteLine(newMessage);
			}
		}
	}
}
