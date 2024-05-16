using real_time_weather_monitoring_and_reporting_service.Strategy;
using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;

namespace real_time_weather_monitoring_and_reporting_service.Tests
{
    public class WeatherContextTesterShould
    {
        private readonly IHumidityThresholdBots _humidityBot;
        private readonly ITempratureThresholdBots _temperatureBot;
        private readonly List<IWeatherBot> _bots;

        public WeatherContextTesterShould() 
        {
            _humidityBot = new RainBot();
            
            _temperatureBot = new SnowBot();
            _bots = new List<IWeatherBot>();
        }
      [Fact]
        public void GetActivatedBotsReturnsCorrectBots()
        {
            _bots.Clear();

            _humidityBot.HumidityThreshold= 50;
            _humidityBot.Enabled= true;


            _temperatureBot.TemperatureThreshold=30;
           _temperatureBot.Enabled=true;
           _bots.Add(_humidityBot);
           _bots.Add(_temperatureBot);
            var weatherContext = new WeatherContext(_bots, 60, 40);
            var activatedBots = weatherContext.GetActivatedBots();

           Assert.Contains(_humidityBot, activatedBots);
           Assert.Contains(_temperatureBot, activatedBots);
        }

        [Fact]
        public void GetActivatedBotsIgnoresDisabledBots()
        {
            _bots.Clear();
            _humidityBot.HumidityThreshold = 70;
            _humidityBot.Enabled = true;


            _temperatureBot.TemperatureThreshold = 30;
            _temperatureBot.Enabled = false;
            _bots.Add(_humidityBot);
            _bots.Add(_temperatureBot);

            var weatherContext = new WeatherContext(_bots, 60, 40);
            var activatedBots = weatherContext.GetActivatedBots();
            Assert.Empty(activatedBots);
        }


    }
}