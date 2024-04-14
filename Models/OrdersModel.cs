using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace DZ15.Models
{
    /// <summary>
    /// Класс описывающий таблицу Orders.
    /// </summary>
    [Table(Name = "orders")]
    internal class OrdersModel
    {
        [PrimaryKey, Identity, Column(Name = "id"), NotNull] public int Id { get; set; }

        [Column(Name = "customerid"), ForeignKey("orders_customerid_fkey")] public int? Customerid { get; set; }

        [Column(Name = "productid"), ForeignKey("orders_productid_fkey")] public int ?Productid { get; set; }

        [Column(Name = "quantity")] public int ?Quantity { get; set; }

    }
    
}
