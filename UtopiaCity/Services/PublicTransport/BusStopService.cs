using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Models.PublicTransport;

namespace UtopiaCity.Services.PublicTransport
{
		public class BusStopService
		{
				private readonly AppDbContext _dbContext;
				private readonly GenericDataProvider<BusStop> _provider;
				
				public BusStopService(AppDbContext context, GenericDataProvider<BusStop> provider)
				{
						_dbContext = context;
						_provider = provider;
				}

				public virtual async Task<List<BusStop>> GetAllRoutesAsync()
				{
						return await _dbContext.BusStop.ToListAsync();
				}

				public BusStop GetBusStop(string id)
				{
						return _provider.Get(id).GetAwaiter().GetResult();
				}

				public void AddNewBusStop(BusStop newStop)
				{
						_provider.Add(newStop).GetAwaiter().GetResult();
				}

				public void UpdateBusStop(BusStop busStop)
				{
						_dbContext.Update(busStop);
						_dbContext.SaveChanges();
				}

				public void RemoveBusStop(BusStop busStop)
				{
						_dbContext.Remove(busStop);
						_dbContext.SaveChanges();
				}
		}
}
