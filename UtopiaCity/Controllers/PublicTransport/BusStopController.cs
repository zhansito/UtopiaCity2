using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UtopiaCity.Common;
using UtopiaCity.Filters;
using UtopiaCity.Models.PublicTransport;
using UtopiaCity.Services.PublicTransport;

namespace UtopiaCity.Controllers.PublicTransport
{
		[CookieFilter]
		public class BusStopController : BaseController
		{
				public const string ControllerName = "BusStop";
				private readonly BusStopService _busStopService;
				private readonly AppConfig _appConfig;

				public BusStopController(BusStopService busStopService, IOptions<AppConfig> options)
				{
						_busStopService = busStopService;
						_appConfig = options.Value;
				}

				[HttpGet]
				[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
				public async Task<ActionResult> Index()
				{
						return View("~/Views/PublicTransport/BusStop/ListBusStopView.cshtml", await _busStopService.GetAllRoutesAsync());
				}

				[HttpGet]
				public ActionResult Details(string id)
				{
						if (string.IsNullOrWhiteSpace(id))
						{
								return NotFound();
						}

						var route = _busStopService.GetBusStop(id);
						if (route == null)
						{
								NotFound();
						}

						return View("~/Views/PublicTransport/BusStop/DetailsBusStopView.cshtml", route);
				}

				[HttpGet]
				public ActionResult Create()
				{
						return View("~/Views/PublicTransport/BusStop/CreateBusStopView.cshtml");
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				public ActionResult Create(BusStop busStop)
				{
						if (!ModelState.IsValid)
						{
								return View("~/Views/PublicTransport/BusStop/CreateBusStopView.cshtml");
						}

						return TryExecuteActionResult(() =>
						{
								_busStopService.AddNewBusStop(busStop);
								return RedirectToAction(nameof(Index));
						});
				}

				[HttpGet]
				public ActionResult Edit(string id)
				{
						if (string.IsNullOrWhiteSpace(id))
						{
								return NotFound();
						}

						var route = _busStopService.GetBusStop(id);
						if (route == null)
						{
								return NotFound();
						}

						return View("~/Views/PublicTransport/BusStop/EditBusStopView.cshtml", route);
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				public ActionResult Edit(string id, BusStop busStop)
				{
						if (id != busStop.Id)
						{
								return NotFound();
						}

						if (ModelState.IsValid)
						{
								_busStopService.UpdateBusStop(busStop);
								return RedirectToAction(nameof(Index));
						}

						return View("~/Views/PublicTransport/BusStop/EditBusStopView.cshtml");
				}

				[HttpGet]
				public ActionResult Delete(string id)
				{
						if (string.IsNullOrWhiteSpace(id))
						{
								return NotFound();
						}

						var route = _busStopService.GetBusStop(id);
						if (route == null)
						{
								return NotFound();
						}

						return View("~/Views/PublicTransport/BusStop/DeleteBusStopView.cshtml", route);
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				[ActionName("Delete")]
				public ActionResult DeleteConfirmed(string id)
				{
						var route = _busStopService.GetBusStop(id);
						if(route == null)
						{
								return NotFound();
						}
						_busStopService.RemoveBusStop(route);
						return RedirectToAction(nameof(Index));
				}
		}
}
