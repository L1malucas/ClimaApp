using System.Net.Http;
using System.Threading.Tasks;

public class WeatherForecastService
{
    private readonly HttpClient httpClient;
    private const string ApiKey = "6c3f1bc597dc52aaaf5f221f09e6a532"; 

    public WeatherForecastService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetWeatherForecast(string cityName)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={ApiKey}";
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        else
        {
            return null;
        }
    }
}
