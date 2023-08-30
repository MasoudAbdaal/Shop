using Domain.Entities.User;
using FluentResults;
using MediatR;
using static Domain.Entities.User.Role;

public record CreateUserCommand
(
    string Name,
    string Email,
    string PhoneNumber,
    string Password,
    UserRoles Role = UserRoles.PURCHASER)
 : IRequest<Result<UserResult>>;