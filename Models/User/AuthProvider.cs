using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class AuthProvider
  {
    public enum Providers : byte
    {
      EMAIL, GOOGLE, FACEBOOK, MICROSOFT
    }

    [Key, Column("id")]
    public Providers ID { get; set; }

    [Column("name"), MaxLength(40)]
    public string? Name { get; set; }


    public ICollection<UserAuthMethod>? UserAuthMethod { get; set; }
  }
}