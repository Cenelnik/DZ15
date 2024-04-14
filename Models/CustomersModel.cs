using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace DZ15.Models
{
    /// <summary>
    /// Класс описывающий таблицу Customers
    /// </summary>
    /// 
    [Table(Name = "customers")]
    internal class CustomersModel
    {
        [PrimaryKey, Column(Name = "id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "age")]
        public int ?Age { get; set; }

        [Column(Name = "firstname")]
        public string ?Firstname { get; set; }

        [Column(Name = "lastname")]
        public string ?Lastname { get; set; }

        [Association(ThisKey = nameof(CustomersModel.Id), OtherKey = nameof(OrdersModel.Customerid))]
        public IEnumerable<OrdersModel> Orders { get; set; } = new List<OrdersModel>();

        public static CustomersModel Build(CustomersModel model, IEnumerable<OrdersModel> orders)
        {
            if(model != null)
            {
                model.Orders = orders;
            }
            return model;
        }
    }
}
