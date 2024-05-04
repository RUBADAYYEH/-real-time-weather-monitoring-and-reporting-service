

namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public interface ITempratureThresholdBots : IWeatherBot
    {
        public float TemperatureThreshold { get; set; }
    }
}
