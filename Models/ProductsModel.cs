using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace DZ15.Models
{
    /// <summary>
    /// Клас описывающий таблицу Products
    /// </summary>
    [Table(Name = "products")]
    internal class ProductsModel
    {
        [PrimaryKey, Column(Name = "id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "name")]
        public int ?Name { get; set; }

        [Column(Name = "description")]
        public string ?Description { get; set; }

        [Column(Name = "stockquantity")]
        public int ?Stockquantity { get; set; }

        [Column(Name = "price")]
        public int ?Price { get; set; }

        [Association(ThisKey = nameof(ProductsModel.Id), OtherKey = nameof(OrdersModel.Productid))]
        public IEnumerable<OrdersModel> Orders { get; set; } = new List<OrdersModel>();
        public static ProductsModel Build(ProductsModel model, IEnumerable<OrdersModel> orders)
        {
            if (model != null)
            {
                model.Orders = orders;
            }
            return model;
        }
    }
}
