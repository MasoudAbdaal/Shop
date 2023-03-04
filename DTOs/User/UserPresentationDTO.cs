using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;

namespace Shop.DTOs
{
  [AutoMap(typeof(User))]
  public class UserPresentationDTO
  {
    public string? Name { get; set; }

    [SourceMember(nameof(User.Email))]
    public string? Mail { get; set; }

    public string? Phone { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoles UserRole { get; set; }

    [SourceMember(nameof(UserInfo))]
    public UserInfoDTO? Info { get; set; }

    public ICollection<UserAuthMethodDTO>? AuthenticationMethods { get; set; }
  }

  public class UserAuthMethodDTO
  {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Providers? AuthProviderID { get; set; }
  }

}