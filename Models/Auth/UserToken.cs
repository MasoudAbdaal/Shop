using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class UserToken
  {
    private readonly string? _userID;
    private readonly string? _userEmail;
    private readonly Role.UserRoles? _userRole;

    public UserToken()
    {
      _userID = default;
      _userEmail = default;
      _userRole = null;

    }

    public UserToken(string userID, string userEmail, Role.UserRoles userRole)
    {
      _userID = userID;
      _userEmail = userEmail;
      _userRole = userRole;

    }

    public string? ID { get { return _userID; } }
    public string? Email { get { return _userEmail; } }
    public Role.UserRoles? Role { get { return _userRole; } }
  }

}