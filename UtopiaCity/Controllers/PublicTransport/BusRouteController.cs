using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using UtopiaCity.Common;
using UtopiaCity.Filters;
using UtopiaCity.Models.PublicTransport;
using UtopiaCity.Services.PublicTransport;

namespace UtopiaCity.Controllers.PublicTransport
{
  //[Authorize]
  [CookieFilter]
  public class BusRouteController: BaseController
  {
	public const string ContollerName = "BusRoute";

	private readonly BusRouteService _busRouteService;
	private readonly AppConfig _appConfig;

	public BusRouteController(BusRouteService busRouteService, IOptions<AppConfig> options)
	{
	  _busRouteService = busRouteService;
	  _appConfig = options.Value;
	}

	[HttpGet]
	[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
	public async Task<ActionResult> Index()
	{
	  return View("~/Views/PublicTransport/ListBusRouteView.cshtml", await _busRouteService.GetAllRoutesAsync());
	}

	[HttpGet]
	public ActionResult Details(string id)
	{
	  if(string.IsNullOrWhiteSpace(id))
	  {
		return NotFound();
	  }

	  var route = _busRouteService.GetBusRoute(id);
	  if(route == null)
	  {
		NotFound();
	  }

	  return View("~/Views/PublicTransport/DetailsBusRouteView.cshtml", route);
	}

	[HttpGet]
	public ActionResult Create()
	{
	  return View("~/Views/PublicTransport/CreateBusRouteView.cshtml");
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(BusRoute busRoute)
	{
	  if(!ModelState.IsValid)
	  {
		return View("~/Views/PublicTransport/CreateBusRouteView.cshtml");
	  }

	  return TryExecuteActionResult(() =>
	  {
		_busRouteService.AddNewBusRoute(busRoute);
		return RedirectToAction(nameof(Index));
	  });
	}

	[HttpGet]
	public ActionResult Edit(string id)
	{
	  if(string.IsNullOrWhiteSpace(id))
	  {
		return NotFound();
	  }

	  var route = _busRouteService.GetBusRoute(id);
	  if(route == null)
	  {
		return NotFound();
	  }

	  return View("~/Views/PublicTransport/EditBusRouteView.cshtml", route);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(string id, BusRoute busRoute)
	{
	  if(id != busRoute.Id)
	  {
		return NotFound();
	  }

	  if(ModelState.IsValid)
	  {
		_busRouteService.UpdateBusRoute(busRoute);
		return RedirectToAction(nameof(Index));
	  }

	  return View("~/Views/PublicTransport/EditBusRouteView.cshtml", busRoute);

	}

	[HttpGet]
	public ActionResult Delete(string id)
	{
	  if(string.IsNullOrWhiteSpace(id))
	  {
		return NotFound();
	  }

	  var route = _busRouteService.GetBusRoute(id);
	  if(route == null)
	  {
		return NotFound();
	  }

	  return View("~/Views/PublicTransport/DeleteBusRouteView.cshtml", route);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ActionName("Delete")]
	public ActionResult DeleteConfirmed(string id)
	{
	  var route = _busRouteService.GetBusRoute(id);
	  if(route == null)
	  {
		return NotFound();
	  }

	  _busRouteService.RemoveBusRoute(route);
	  return RedirectToAction(nameof(Index));
	}
  }
}
