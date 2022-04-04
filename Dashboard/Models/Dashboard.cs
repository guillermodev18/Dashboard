using Dashboard.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class Dashboard : DbConnection
    {
        // Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string,int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<KeyValuePair<string, int>> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        // Constructor
        public Dashboard()
        {

        }

        // Private Methods
        private void GetNumberItems()
        {
            using(var connection = GetMySqlConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.Connection = connection;

                    // Get Total Number of Customers
                    command.CommandText = "SELECT COUNT(CustomerId) FROM Customer";
                    NumCustomers = (int)command.ExecuteScalar();

                    // Get Total Number of Suppliers
                    command.CommandText = "SELECT COUNT(SupplierId) FROM Supplier";
                    NumSuppliers = (int)command.ExecuteScalar();

                    // Get Total Number of Products
                    command.CommandText = "SELECT COUNT(ProductId) FROM Product";
                    NumProducts = (int)command.ExecuteScalar();

                    // Get Total Number of Orders
                    command.CommandText = "SELECT COUNT(OrderId) FROM [Order] WHERE OrderDate between @fromDate AND @toDate;";
                    command.Parameters.Add("@fromDate", System.Data.DbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.DbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
        }

        private void GetOrderAnalisys()
        {

        }
    }
}
