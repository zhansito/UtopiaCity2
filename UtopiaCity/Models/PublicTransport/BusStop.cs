using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Common.Attributes;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.PublicTransport
{
		public class BusStop : BaseObject
		{
				public string Name { get; set; }
		}
}
