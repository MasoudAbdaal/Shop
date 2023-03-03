using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;

namespace Shop.DTOs
{
  public class UserPresentationDTO
  {
    public string? Name { get; set; }

    public string? Mail { get; set; }

    [SourceMember(nameof(User.UserInfo.PhoneNumber))]
    public string? Phone { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoles UserRole { get; set; }

    public UserInfoDTO? Info { get; set; }

    public ICollection<UserAuthMethodDTO>? AuthenticationMethods { get; set; }

  }


  public class UserAuthMethodDTO
  {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Providers? AuthProviderID { get; set; }
  }

}