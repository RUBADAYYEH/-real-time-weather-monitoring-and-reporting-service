using real_time_weather_monitoring_and_reporting_service.BotConfigurationLoader;
using real_time_weather_monitoring_and_reporting_service.Strategy;
using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;

namespace real_time_weather_monitoring_and_reporting_service
{
    public class Program
    {

        public static void Main()
        {
            List<IWeatherBot> bots = ConfigurationLoader.LoadAllConfigs("C:\\Users\\Lenovo\\source\\repos\\real-time-weather-monitoring-and-reporting-service\\data.json");
            var context = new WeatherContext(bots, 40f, 37f);
            var Active = context.GetActivatedBots();
            if (Active is not null)
            {
                foreach (IWeatherBot bot in Active)
                {
                    Console.WriteLine(bot.Message);
                }
            }


        }
    }
}