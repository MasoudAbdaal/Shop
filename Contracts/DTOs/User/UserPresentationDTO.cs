using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Domain.Entities.User;

namespace Contracts.DTOs.User;

[AutoMap(typeof(Domain.Entities.User.User))]
public class UserPresentationDTO
{
    public string? Name { get; set; }

    [SourceMember(nameof(Domain.Entities.User.User.Email))]
    public string? Mail { get; set; }

    public string? Phone { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role.UserRoles UserRole { get; set; }

    [SourceMember(nameof(UserInfo))]
    public UserInfoDTO? Info { get; set; }

    public ICollection<UserAuthMethodDTO>? AuthenticationMethods { get; set; }
}

public class UserAuthMethodDTO
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Domain.Entities.Auth.AuthProvider.Providers? AuthProviderID { get; set; }
}