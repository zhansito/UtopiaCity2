using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicTransport;

namespace UtopiaCity.Common.SubDbInitializers
{
		public class BusStopInitializer : ISubDbInitializer
		{
				public void ClearSet(AppDbContext context)
				{
						if (!context.BusStop.Any())
						{
								return;
						}

						context.RemoveRange(context.BusStop.ToList());
						context.SaveChanges();
				}

				public void InitializeSet(AppDbContext context)
				{
						if (context.BusStop.Any())
						{
								return;
						}

						var stop = new BusStop
						{
								Name = "KinderGarden Dauren"
						};

						context.AddRange(stop);
						context.SaveChanges();
				}
		}
}
