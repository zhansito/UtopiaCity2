using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Models.PublicTransport;

namespace UtopiaCity.Services.PublicTransport
{
		public class BusRouteService
		{
				private readonly AppDbContext _dbContext;
				private readonly GenericDataProvider<BusRoute> _provider;
				public BusRouteService(AppDbContext context, GenericDataProvider<BusRoute> provider)
				{
						_dbContext = context;
						_provider = provider;
				}

				public virtual async Task<List<BusRoute>> GetAllRoutesAsync()
				{
						return await _dbContext.BusRoute.ToListAsync();
				}

				public BusRoute GetBusRoute(string id)
				{
						return _provider.Get(id).GetAwaiter().GetResult();
				}

				public void AddNewBusRoute(BusRoute newRoute)
				{
						_provider.Add(newRoute).GetAwaiter().GetResult();
				}

				public void UpdateBusRoute(BusRoute busRoute)
				{
						_dbContext.Update(busRoute);
						_dbContext.SaveChanges();
				}

				public void RemoveBusRoute(BusRoute busRoute)
				{
						_dbContext.Remove(busRoute);
						_dbContext.SaveChanges();
				}
		}
}
