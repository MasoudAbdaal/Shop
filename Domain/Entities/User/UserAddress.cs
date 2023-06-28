using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Address;

namespace Domain.Entities.User;

public class UserAddress
{
    // [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    // [ForeignKey(nameof(Address)), Column("address_id")]
    public byte[] AddressID { get; set; } = new byte[4];

    public User? User { get; set; }
    public Domain.Entities.Address.Address? Address { get; set; }
}
