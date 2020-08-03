using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace Cinema.DAL.Global.Repositories
{
    public abstract class BasicRepository
    {
        protected Connection _connection;
        private ConnectionStringSettings ConnectionString { get { return ConfigurationManager.ConnectionStrings["MoviesDB.SqlClient"]; } }

        public BasicRepository()
        {
            _connection = new Connection(ConnectionString.ConnectionString, ConnectionString.ProviderName);
        }
    }
}
