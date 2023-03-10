
namespace Shop.DTOs
{

  public class AddressDeleteDTO
  {
    public byte[] AddressID { get; set; } = new byte[4];
    public byte[] UserID { get; set; } = new byte[16];
  }

}