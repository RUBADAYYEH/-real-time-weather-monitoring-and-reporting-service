using System.Text.Json;
namespace real_time_weather_monitoring_and_reporting_service.WeatherData.JsonData
{
    public class JsonWeatherDataLoader : IWeatherDataLoader
    {
        public WeatherData GetWeatherData(string jsonString)
        {
            WeatherData? weatherData = JsonSerializer.Deserialize<WeatherData>(jsonString);
            return weatherData!;
        }
    }
}
