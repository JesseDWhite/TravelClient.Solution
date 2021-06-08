using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    public string DestinationName { get; set; } //

    [Required]
    public string Country { get; set; }

    [Required]
    public string StateProvince { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Category { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be from 1 as the lowest and 5 as the highest.")]
    public int Rating { get; set; }
    [Required]
    public string DestinationDesctription { get; set; }

    public static List<Destination> GetDestinations()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

      return destinationList;
    }
  }
}