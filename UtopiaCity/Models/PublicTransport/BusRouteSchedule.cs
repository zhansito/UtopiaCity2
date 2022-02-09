using System;
using System.Collections.Generic;

namespace UtopiaCity.Models.PublicTransport
{
		public class BusRouteSchedule
		{
				public BusRoute BusRoute { get; set; }
				public List<DateTime> ArriveTime { get; set; }
		}
}
