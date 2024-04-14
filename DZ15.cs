using LinqToDB;
using LinqToDB.DataProvider.PostgreSQL;

namespace DZ15
{
    /// <summary>
    /// 15я домашка по OUTUS. Daper or LinqDB
    /// BD - postgresql 
    /// </summary>
    class DZ15
    {
        public static void Main(string[] args)
        {

            var options = new DataOptions().UsePostgreSQL("Server = localhost; Database = Shop; User Id = postgres; Password = 1HUF!zLRnCKM-kV0;");
            MySQL sql = new MySQL(options);


            Console.WriteLine($"\n\n * * * First query: Select * from Customers");
            //1й простой запрос
            foreach (var user in sql.Customers)
            {
                Console.WriteLine($"{user.Id}, {user.Firstname}, {user.Age}");
            }


            //2й простой запрос
            Console.WriteLine($"\n\n * * * Second query: Select * from Customers where Age > 30");
            foreach (var user in sql.Customers.Where(t => t.Age > 30).ToArray())
            {
                Console.WriteLine($"{user.Id}, {user.Firstname}, {user.Age}");
            }

            //3й запрос c JOIN
            Console.WriteLine($"\n\n * * * Third query: Select * from Customers c LEFT JION Orders o ON c.Id = o.CustomersId");
            Console.WriteLine($"Customets.Id\tCustomet.FirstName\tCustomer.Age\tOrders.Id\tOrders.Productid\tOrders.Quantity");
            foreach (var user in sql.Customers.LoadWith(c => c.Orders))
            {
                if (user.Orders.Count() != 0)
                {
                    Console.WriteLine($"{user.Id}\t{user.Firstname}\t{user.Age}\t{user.Orders.First().Id}\t{user.Orders.First().Productid}\t{user.Orders.First().Quantity}");
                }
                else
                {
                    Console.WriteLine($"{user.Id}\t{user.Firstname}\t{user.Age}\tNULL\tNULL\tNULL");
                }
            }


            Console.Read();
        }
    }
}