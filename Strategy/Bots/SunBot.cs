using System.Text.Json.Serialization;
namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    internal class SunBot : ITempratureThresholdBots
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        [JsonPropertyName("temperatureThreshold")]
        public float TemperatureThreshold { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get ; set; }
        public void ActivateBot()
        {
            Console.WriteLine("SunBot Activated");
            Console.WriteLine("Wow, it's a scorcher out there!");
        }
        public override string ToString()
        {
            return this.TemperatureThreshold + " " + this.Message;
        }
    }
}
