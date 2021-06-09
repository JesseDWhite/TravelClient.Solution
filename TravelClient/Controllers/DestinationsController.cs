using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class DestinationsController : Controller
  {
    public IActionResult Index()
    {
      var allDestinations = Destination.GetDestinations();
      return View(allDestinations);
    }
    //this creates a new instance of destination
    [HttpPost]
    public IActionResult Index(Destination destination)
    {
      Destination.Post(destination);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var thisDestinations = Destination.GetDetails(id);
      return View(thisDestinations);
    }
    [HttpPost]
    public IActionResult Details(int id, Destination destination)
    {
      destination.DestinationId = id;
      Destination.Put(destination);
      return RedirectToAction("Details", id);
    }

    public IActionResult Edit(int id)
    {
      var destination = Destination.GetDetails(id);
      return View(destination);
    }
    [HttpPost]
    public IActionResult Edit(int id, Destination destination)
    {
      destination.DestinationId = id;
      Destination.Put(destination);
      return RedirectToAction("Edit", id);
    }

    public IActionResult Delete(int id)
    {
      Destination.Delete(id);
      return RedirectToAction("Index");
    }
  }
}