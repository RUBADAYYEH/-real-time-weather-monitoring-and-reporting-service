using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;


namespace real_time_weather_monitoring_and_reporting_service.BotConfigurationLoader
{
    public interface IConfigurationLoader
    {
        public List<IWeatherBot> LoadAllConfigs(string path);
       

    }
}
