
namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public interface IWeatherBot
    {
        public bool Enabled { get; set; }

        public string Message { get; set; }
        public void ActivateBot();



    }
}
