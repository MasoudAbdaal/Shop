using Domain.Entities.User;

namespace Domain.Entities.Auth;

public class VerificationMethod
{
    public enum VerifyMethods : byte
    {
        NONE, SMS, EMAIL, TOKEN, SMS_AND_EMAIL
    }

    public VerifyMethods ID { get; set; }

    public string? Name { get; set; }


    public ICollection<UserVerificationMethod>? UserVerificationMethods { get; set; }
}
