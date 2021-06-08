using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"destinations", Method.GET); // might need to be lowercase? From DB
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}