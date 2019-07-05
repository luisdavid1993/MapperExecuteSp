using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class ConfigurationDTO
    {
          public static string ConnectionString
        {
            get
            {

                string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                if (string.IsNullOrEmpty(cadena))
                    throw new ProviderException("Error retrieving connection string. Check the section <connectionStrings> in the configuration file.");

                return cadena;
            }
        }
    }
}
