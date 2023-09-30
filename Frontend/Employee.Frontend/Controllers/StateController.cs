using Employee.Frontend.Models;
using Employee.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Employee.Frontend.Controllers;

    public class StateController : Controller
    {

        private readonly HttpClient _httpClient;
    //public StateController(IHttpClientFactory httpClient) 
    //{
    //    _httpClient = httpClient.CreateClient("EmployeeAPIBase");

    //}

    public StateController(IHttpClientFactory httpClient)=> _httpClient = httpClient.CreateClient("EmployeeAPIBase");

    

    //private async Task<IEnumerable<State>> GetAllState()
    //{
    //    var responce = await _httpClient.GetAsync("State");
    //    if (responce.IsSuccessStatusCode)

    //    {
    //        var content = await responce.Content.ReadAsStringAsync();
    //        var states = JsonConvert.DeserializeObject<List<State>>(content);
    //        return states!;
    //    }
    //    return new List<State>();
    //}

    public async Task<List<State>> GetAllState()
    {
        var response = await _httpClient.GetFromJsonAsync<List<State>>("State");
        return response is not null ? response : new List<State>();
    }



    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var data = await GetAllState();
        return View(data);
    }
}

