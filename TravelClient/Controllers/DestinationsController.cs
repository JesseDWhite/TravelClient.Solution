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
      return View();
    }

    public IActionResult Details(int id)
    {
      var thisDestinations = Destination.GetDetails(id);
      return View(thisDestinations);
    }
  }
}