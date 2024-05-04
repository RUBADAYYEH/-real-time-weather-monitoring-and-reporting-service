using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;


namespace real_time_weather_monitoring_and_reporting_service.Strategy
{
    public class WeatherContext(List<IWeatherBot> bots, float humidityThreshold, float temperatureThreshold)
    {
        List<IWeatherBot> Bots { get; } = bots;
        float TemperatureThreshold { get; set; } = humidityThreshold;
        float HumidityThreshold { get; set; } = temperatureThreshold;

        public List<IWeatherBot> GetActivatedBots()
        {
            var activationRulesForHumidityThresholdBots = GetActivationRulesForHumidityBots();
            var activationRulesForTempratureThresholdBots = GetActivationRulesForTempratureBots();
            var weatherBots = Bots.Where(e => e.GetType() == typeof(RainBot) ? GetHumidityBotWithActivation(e, activationRulesForHumidityThresholdBots) : GetTempratureBotWithActivation(e, activationRulesForTempratureThresholdBots)).ToList();
            return   [.. weatherBots] ;
        }
    
        public static bool GetHumidityBotWithActivation(IWeatherBot R, List<Func<IWeatherBot, bool>> Rules)
        {

            var test = Rules.Where(a => a(R));
            return test.Count() == 2;

        }
        public static bool GetTempratureBotWithActivation(IWeatherBot R, List<Func<IWeatherBot, bool>> Rules)
        {

            var test = Rules.Where(a => a(R));

            return test.Count() >= 2;

        }



        public List<Func<IWeatherBot, bool>> GetActivationRulesForTempratureBots()
        {
            var Rules = new List<Func<IWeatherBot, bool>> {

        IsBelowTemperatureThreshold,
        IsEnabled
        };
            return Rules;
        }
        public List<Func<IWeatherBot, bool>> GetActivationRulesForHumidityBots()
        {
            var Rules = new List<Func<IWeatherBot, bool>> {
        IsBelowHumidityThreshold,
        IsEnabled
        };
            return Rules;
        }
        public bool IsBelowHumidityThreshold(IWeatherBot r)
        {
            return ((IHumidityThresholdBots)(r)).HumidityThreshold < HumidityThreshold;
        }

        public bool IsBelowTemperatureThreshold(IWeatherBot r)
        {
            return ((ITempratureThresholdBots)(r)).TemperatureThreshold < TemperatureThreshold;
        }

        public static bool IsEnabled(IWeatherBot r)
        {
            return r.Enabled;
        }

    }
}

