    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MySqlConnector;

    namespace POS_System
    {
        
        public class Connector
        {

            private string _connectionString =
                "server=localhost;database=xample;user=root;password=";

            private MySqlConnection _connection;

            public Connector()
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
            }
            
            public MySqlDataReader Query(string command)
            {
                
                return new MySqlCommand(command, _connection).ExecuteReader();
            }

            public void Close()
            {
                _connection.Close();
            }

            public void InitState()
            {
                Query("create database if not exists kwiksight").Close();
                Query("use kwiksight").Close();
                Query("create table if not exists Industry (" +
                      "industryID bigint primary key auto_increment," +
                      "industryName varchar(256))").Close();
                Query("create table if not exists Brand(" +
                      "brandID bigint primary key auto_increment," +
                      "brandName varchar(256)," +
                      "industryID bigint references industry)").Close();
                Query("create table if not exists Tag(" +
                      "tagID bigint primary key," +
                      "tagName varchar(256))").Close();
                Query("create table if not exists Product (" +
                      "productId bigint primary key auto_increment," +
                      "productName varchar(256)," +
                      "price decimal(15, 2)," +
                      "brandID bigint references brand," +
                      "tagID bigint references Tag);").Close();
                Query("create table if not exists Purchase (" +
                      "orderID bigint primary key auto_increment," +
                      "orderEvent datetime," +
                      "orderAmount integer, " +
                      "productID bigint references product)").Close();
            }
            

        }
    }