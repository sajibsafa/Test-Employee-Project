using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text.Json;

namespace Employee.Frontend.Controllers;

public class CountryController : Controller
{
    private readonly HttpClient _httpClient;

    public CountryController(IHttpClientFactory httpClient)=>  _httpClient = httpClient.CreateClient("EmployeeAPIBase");
    

    //private async Task<IEnumerable<Countrys>> GetAllCountry()
    //{
    //    var responce = await _httpClient.GetAsync("Country");
    //    if (responce.IsSuccessStatusCode)
    //    {
    //        var content = await responce.Content.ReadAsStringAsync();
    //        var countries = JsonConvert.DeserializeObject<IEnumerable<Countrys>>(content);
    //        return countries!;
    //    }
    //    return new List<Countrys>();
    //}

    public async Task<List<Countrys>> GetAllCountry()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Countrys>>("Country");
        return response is not null ? response : new List<Countrys>();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var data = await GetAllCountry();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> AddOrEdit(int Id)
    {
        if(Id == 0)
        {
            return View(new Countrys());
        }
        else
        {
            var data = await _httpClient.GetAsync($"Country/Id:int?Id={Id}");
            if (data.IsSuccessStatusCode)
            {
                var result =await data.Content.ReadFromJsonAsync<Countrys>();
                return View(result);
            }


        }
        return View(new Countrys());    
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> AddOrEdit(int Id,Countrys countrys)
    {
        if (ModelState.IsValid )
        {
            if(Id==0)
            {
                var result = await _httpClient.PostAsJsonAsync("Country", countrys);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync($"Country/{Id}", countrys);
                if(result.IsSuccessStatusCode) { return RedirectToAction("Index"); }
            }
            

        }
        return View(new Countrys());
    }


    public async Task<IActionResult> Delete(int Id)
    {
        var data = await _httpClient.DeleteAsync($"Country/{Id}");
        if (data.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else return NotFound();
    }
}
