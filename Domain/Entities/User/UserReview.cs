using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Order;

namespace Domain.Entities.User;

public class UserReview
{
    public uint ID { get; set; }

    public byte[]? UserID { get; set; } = new byte[16];

    public byte[] OrderLineID { get; set; } = new byte[32];

    public byte? Rate { get; set; }

    public string? Comment { get; set; }

    public User? User { get; set; }
    public OrderLine? OrderLine { get; set; }
}
