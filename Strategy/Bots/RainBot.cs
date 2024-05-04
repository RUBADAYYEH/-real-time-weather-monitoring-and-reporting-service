using System.Text.Json.Serialization;


namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public class RainBot : IHumidityThresholdBots
    {

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("humidityThreshold")]
        public float HumidityThreshold { get; set; }


        [JsonPropertyName("message")]
        public string Message { get; set; }



        public void ActivateBot()
        {
            Console.WriteLine("It looks like it's about to pour down!");
        }
        public override string ToString()
        {
            return this.HumidityThreshold + " " + this.Message;
        }
    }
}
