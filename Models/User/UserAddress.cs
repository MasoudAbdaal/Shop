using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{


  public class UserAddress
  {
    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    [ForeignKey("Address"), Column("address_id")]
    public uint AddressID { get; set; }

    public User? User { get; set; }
    public Address? Address { get; set; }
  }
}