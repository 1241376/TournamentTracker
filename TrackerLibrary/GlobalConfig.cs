using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection connection { get; private set; }

        public static void initializeConnections(DatabaseTpe db)
        {
            if (db == DatabaseTpe.Sql)
            {
                SqlConnector sql = new SqlConnector();
                connection = sql;
            }

            else if (db == DatabaseTpe.TextFile)
            {
                TextConnector text = new TextConnector();
                connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
