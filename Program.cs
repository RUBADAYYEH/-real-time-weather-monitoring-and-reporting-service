using real_time_weather_monitoring_and_reporting_service.BotConfigurationLoader;
using real_time_weather_monitoring_and_reporting_service.BotConfigurationLoader.DataManagement.Json;
using real_time_weather_monitoring_and_reporting_service.Strategy;
using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;
using real_time_weather_monitoring_and_reporting_service.WeatherData;
using real_time_weather_monitoring_and_reporting_service.WeatherData.JsonData;

namespace real_time_weather_monitoring_and_reporting_service
{
    public class Program
    {

        public static void Main()
        {
            var config = new JsonLoader();
            var bots = config.LoadAllConfigs("C:\\Users\\Lenovo\\source\\repos\\real-time-weather-monitoring-and-reporting-service\\BotConfigurationLoader\\DataManagement\\data.json");
            var dataLoader = new JsonWeatherDataLoader();
            var weather= dataLoader.GetWeatherData(Console.ReadLine()??"");
           

            var context = new WeatherContext(bots,weather.HumidityThreshold,weather.TemperatureThreshold);
            var Active = context.GetActivatedBots();
            if (Active is not null)
            {
                foreach (IWeatherBot bot in Active)
                {
                    Console.WriteLine();
                    bot.ActivateBot();
                }
            }


        }
    }
}