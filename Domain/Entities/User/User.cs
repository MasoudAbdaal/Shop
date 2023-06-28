using System.Collections.ObjectModel;

using Domain.Entities.Auth;
using static Domain.Entities.User.Role;

namespace Domain.Entities.User;

public class User
{

    public byte[] ID { get; set; } = new byte[16];

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public byte[] Password { get; set; } = new byte[64];

    public byte[] PasswordSalt { get; set; } = new byte[128];

    public string? ResetPasswordToken { get; set; }

    public UserRoles UserRoleID { get; set; } = UserRoles.PURCHASER;

    public DateTime? ResetPasswordTokenExpires { get; set; }

    public uint? SMS_Code { get; set; }

    public uint? Token_Code { get; set; }

    public uint? Email_Code { get; set; }


    public Role? Role { get; set; }

    public UserInfo? UserInfo { get; set; } = new UserInfo { CreateDate = DateTime.UtcNow, PhoneNumber_Verified = false };

    public ICollection<UserAuthMethod>? UserAuthMethods { get; set; } = new Collection<UserAuthMethod> {
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.EMAIL}};

    public ICollection<UserVerificationMethod>? UserVerificationMethods { get; set; }

    public ICollection<UserAddress>? UserAddress { get; set; }

    public ICollection<Domain.Entities.Cart.Cart>? Cart { get; set; }

    public ICollection<Domain.Entities.Payment.Payment>? Payment { get; set; }

    public ICollection<UserReview>? UserReview { get; set; }

    public ICollection<Domain.Entities.Order.Order>? Order { get; set; }
}
