using System.Text.Json.Serialization;
namespace real_time_weather_monitoring_and_reporting_service.WeatherData
{
    public class WeatherData
    {
        [JsonPropertyName("Location")]
        public string? Location { get; set; }
        [JsonPropertyName("Temperature")]
        public float TemperatureThreshold { get; set; }
        [JsonPropertyName("Humidity")]
        public float HumidityThreshold { get; set; }
    }
}
