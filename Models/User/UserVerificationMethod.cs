using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shop.Models.VerificationMethod;

namespace Shop.Models
{
  public class UserVerificationMethod
  {
    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? UserID { get; set; }

    public User? Users { get; set; }

    [ForeignKey("VerificationMethod"), Column("verify_method_id"),]
    public VerifyMethods? VerificationMethodID { get; set; }

    public VerificationMethod? VerificationMethod { get; set; }

  }
}