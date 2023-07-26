using static Domain.Entities.Auth.AuthProvider;
namespace Contracts.DTOs.User;

public class UserPresentationDTO
{
    public string? Name { get; set; }

    public string? Mail { get; set; }

    public string? Phone { get; set; }

    public string? UserRole { get; set; }

    public UserInfoDTO? Info { get; set; }

    public ICollection<UserAuthMethodDTO>? AuthenticationMethods { get; set; }
}

public class UserAuthMethodDTO
{
    public byte? AuthProviderID { get; set; }
}