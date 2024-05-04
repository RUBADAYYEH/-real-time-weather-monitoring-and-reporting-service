using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public class SnowBot : ITempratureThresholdBots
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("temperatureThreshold")]
        public float TemperatureThreshold { get; set; }


        [JsonPropertyName("message")]
        public string Message { get; set; }


        public void ActivateBot()
        {
            Console.WriteLine("Brrr, it's getting chilly!");
        }
        public override string ToString()
        {
            return this.TemperatureThreshold + " " + this.Message;
        }
    }
}
