using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;

namespace Domain.Entities.Auth;

public class VerificationMethod
{
    public enum VerifyMethods : byte
    {
        NONE, SMS, EMAIL, TOKEN, SMS_AND_EMAIL
    }

    [Key, Column("id")]
    public VerifyMethods ID { get; set; }

    [Column("name"), MaxLength(40)]
    public string? Name { get; set; }


    public ICollection<UserVerificationMethod>? UserVerificationMethod { get; set; }

}
