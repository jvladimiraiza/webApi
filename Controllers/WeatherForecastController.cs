using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("get/weatherforecast")]
    [Route("get/weatherforecast2")]
    [Route("[action]")] // ruta de acuerdo al nombre del metodo en este ejemplo es /getw
    public IEnumerable<WeatherForecast> GetW()
    {
        return ListWeatherForecast;
    }
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok("El registro se inserto correctamente");
    }
    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        try
        {
            var countListWeatherForecast = ListWeatherForecast.Count();
            int[] list = this.generarArray(countListWeatherForecast);
            if (this.existIndice(index, list))
            {
                ListWeatherForecast.RemoveAt(index);
                return Ok("Se elimino el registro con la posicion n° "+ index);
            } else {
                return BadRequest("El indice no se encuentra dentro de la lista");
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            return BadRequest("Error, el indice no se encuentra dentro de la lista");
        }
    }
    private int[] generarArray(int tamanio)
    {
        int[] arrayList = new int[tamanio];
        for (int i = 0; i < arrayList.Count(); i++)
        {
            arrayList[i] = i;
        }
        return arrayList;
    }
    private bool existIndice(int indice, int[] listArray)
    {
        for (var i = 0;  i < listArray.Length; i++)
        {
            if (listArray[i] == indice)
            {
                return true;
            }
        }
        return false;
    }
}
