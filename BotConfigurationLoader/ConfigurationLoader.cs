using System.Text.Json;
using real_time_weather_monitoring_and_reporting_service.Strategy.Bots;


namespace real_time_weather_monitoring_and_reporting_service.BotConfigurationLoader
{
    public class ConfigurationLoader
    {
        public static List<IWeatherBot> LoadAllConfigs(string path)
        {
            try
            {

                using JsonDocument doc = JsonDocument.Parse(File.OpenRead(path));

                var botConfigurations = new Dictionary<string, JsonElement>();


                foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                {

                    botConfigurations.Add(property.Name, property.Value);
                }

                RainBot? rainBot = JsonSerializer.Deserialize<RainBot>(botConfigurations["RainBot"].GetRawText());

                SunBot? sunBot = JsonSerializer.Deserialize<SunBot>(botConfigurations["SunBot"].GetRawText());

                SnowBot? snowBot = JsonSerializer.Deserialize<SnowBot>(botConfigurations["SnowBot"].GetRawText());



                return [rainBot ?? new RainBot(), sunBot ?? new SunBot(), snowBot ?? new SnowBot()];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return [];

        }


    }
}
