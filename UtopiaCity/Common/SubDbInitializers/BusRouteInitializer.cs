using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicTransport;

namespace UtopiaCity.Common.SubDbInitializers
{
  public class BusRouteInitializer: ISubDbInitializer
  {
	public void ClearSet(AppDbContext context)
	{
	  if(!context.BusRoute.Any())
	  {
		return;
	  }

	  context.RemoveRange(context.BusRoute.ToList());
	  context.SaveChanges();
	}

	public void InitializeSet(AppDbContext context)
	{
	  if(context.BusRoute.Any())
	  {
		return;
	  }

	  var route = new BusRoute
	  {
		StartStation = ""
	  };

	  context.AddRange(route);
	  context.SaveChanges();
	}
  }
}
