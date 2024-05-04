using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_time_weather_monitoring_and_reporting_service.Strategy.Bots
{
    public interface ITempratureThresholdBots : IWeatherBot
    {
        public float TemperatureThreshold { get; set; }
    }
}
