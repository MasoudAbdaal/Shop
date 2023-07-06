using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using static Domain.Entities.Auth.VerificationMethod;

namespace Domain.Entities.User;

public class UserVerificationMethod
{
    public byte[]? UserID { get; set; }

    public VerifyMethods? VerificationMethodID { get; set; }

    public User? User { get; set; }
    public VerificationMethod? VerificationMethod { get; set; }
}
