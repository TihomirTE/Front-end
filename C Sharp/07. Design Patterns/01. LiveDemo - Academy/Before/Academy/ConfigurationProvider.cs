using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
