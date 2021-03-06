using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Common.Attributes;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.PublicTransport
{
		public class BusRoute : BaseObject
		{
				public string Name { get; set; }
				public List<BusStop> BusStops { get; set; }
				public int BusQuantity { get; set; }
		}
}
