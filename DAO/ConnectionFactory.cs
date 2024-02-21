using MySql.Data.MySqlClient;

namespace APIUsuarios.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            var connectionString = "Server=localhost;Database=Apostila;Uid=root;Pwd=root";
            return new MySqlConnection(connectionString);
        }
    }
}
