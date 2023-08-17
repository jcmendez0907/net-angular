using System.Data.SqlClient;
using net_angular_ci.Models;

namespace net_angular_ci.Services
{
    public class ProductService
    {
        public static string db_source = "net-angular.database.windows.net";
        public static string db_user = "ci-cd-admin";
        public static string db_password = "P455w0rd1234";
        public static string db_database = "net-angular";

        private SqlConnection GetConnection(){
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _productList = new List<Product>();
            string statement = "SELECT ProductID, ProductName, Quantity from Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _productList.Add(product);
                    
                }
            }
            conn.Close();
            return _productList;
        }
    }
    
}