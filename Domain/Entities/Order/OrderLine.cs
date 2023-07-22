using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product;
using Domain.Entities.User;

namespace Domain.Entities.Order;

public class OrderLine
{
    public byte[] ID { get; set; } = new byte[32];

    public byte ProductItemID { get; set; }

    public byte[] OrderID { get; set; } = new byte[32];

    public uint Quantity { get; set; }

    public decimal Price { get; set; }

    public ICollection<UserReview>? UserReviews { get; set; }

    public ProductItem? ProductItem { get; set; }
    
    public Order? Order { get; set; }
}
