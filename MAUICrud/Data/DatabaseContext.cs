using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrud.Data
{
    public class DatabaseContext
    {
        string connectionString = "Server=127.0.0.1;Port=5433;Database=MAUIcrudDB;User Id=postgres;Password=2345;";

        NpgsqlConnection _connection;
        NpgsqlConnection DataBase => (_connection ??= new NpgsqlConnection(connectionString));



    }
}
