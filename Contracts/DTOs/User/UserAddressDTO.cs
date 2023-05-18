using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.DTOs.User;

public class UserAddressDTO
{
    public string? Email { get; set; }
    public string? Street { get; set; }
}
