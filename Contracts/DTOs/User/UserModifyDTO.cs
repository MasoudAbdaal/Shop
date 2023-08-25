using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.DTOs.User;

public class UserModifyDTO
{
    [Required, MaxLength(40), MinLength(5)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(40)]
    public string Mail { get; set; } = string.Empty;

    public UserInfoDTO? info { get; set; }
}

public class UserInfoDTO 
{
}