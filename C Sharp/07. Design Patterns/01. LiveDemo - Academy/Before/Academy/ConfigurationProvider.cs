using System.Configuration;

namespace Academy
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public bool IsTestEnvironment
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);
            }
        }
    }
}
