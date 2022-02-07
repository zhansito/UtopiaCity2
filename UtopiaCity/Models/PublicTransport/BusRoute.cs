using System;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Common.Attributes;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.PublicTransport
{
  public class BusRoute : BaseObject
  {
	public string StartStation { get; set; }
	public string FinalStation { get; set; }
	public string BusStops { get; set; }
	public int BusQuantity { get; set; }

	public BusRoute() { }
	public BusRoute(string id, string startStation, string finalStation, int busQuantity)
	{
	  Id = id;
	  StartStation = startStation;
	  FinalStation = finalStation;
	  BusQuantity = busQuantity;
	}
  }
}
