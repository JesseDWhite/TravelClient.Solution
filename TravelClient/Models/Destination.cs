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

    public string DestinationName { get; set; }

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
    public string DestinationDescription { get; set; }

    public static List<Destination> GetDestinations()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

      return destinationList;
    }
    public static Destination GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

      return destination;
    }

    public static void Post(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      var apiCallTask = ApiHelper.Post(jsonDestination);
    }

    public static void Put(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      var apiCallTask = ApiHelper.Put(destination.DestinationId, jsonDestination);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}