
using LinqToDB;
using LinqToDB.Data;

namespace DZ15
{
    internal class MySQL: DataConnection
    {
        
        string _host;
        string _db;
        string _user;
        string _pwd;
        public MySQL(DataOptions<MySQL> options)
        : base(options.Options) { }

        public MySQL(DataOptions options) : base(options)
        {
        }

        public ITable<Models.ProductsModel> Products => this.GetTable<Models.ProductsModel>();
        public ITable<Models.CustomersModel> Customers => this.GetTable<Models.CustomersModel>();
        public ITable<Models.OrdersModel> Orders => this.GetTable<Models.OrdersModel>();
        
       
    }
}
