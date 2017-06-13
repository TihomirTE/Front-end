using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    public interface IConfigurationProvider
    {
        bool IsTestEnvironment { get; }
    }
}
