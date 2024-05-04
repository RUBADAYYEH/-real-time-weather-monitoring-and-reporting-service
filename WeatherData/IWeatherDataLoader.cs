
namespace real_time_weather_monitoring_and_reporting_service.WeatherData
{
    public interface IWeatherDataLoader
    {
        WeatherData GetWeatherData(string weatherData);
    }
}
