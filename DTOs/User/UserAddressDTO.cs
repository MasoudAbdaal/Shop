using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DTOs
{
  public class UserAddressDTO
  {
    public string? Email { get; set; }
    public string? Street { get; set; }
  }
}
