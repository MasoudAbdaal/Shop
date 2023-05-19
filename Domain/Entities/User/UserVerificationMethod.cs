using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using static Domain.Entities.Auth.VerificationMethod;

namespace Domain.Entities.User;

public class UserVerificationMethod
{
    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? UserID { get; set; }

    public User? Users { get; set; }

    [ForeignKey(nameof(VerificationMethod)), Column("verify_method_id"),]
    public VerifyMethods? VerificationMethodID { get; set; }

    public VerificationMethod? VerificationMethod { get; set; }

}
