using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Order;

public class OrderShippingMethod
{
    public enum ShippingMethods : byte
    {
        POST, EXPRESS
    }

    public ShippingMethods ID { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public ICollection<Order>? Orders { get; set; }
}
