namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public interface IHumidityThresholdBots : IWeatherBot
    {
        public float HumidityThreshold { get; set; }
    }
}
