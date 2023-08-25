using System.Security.Cryptography;
using Contracts.DbContexts;
using Domain.Entities.User;
using FluentResults;
using Infrastructure.Identity;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserResult>>
{
    private readonly IUserDbContext _userDbContext;

    public CreateUserCommandHandler(IUserDbContext userDbContext) => _userDbContext = userDbContext;


    public async Task<Result<UserResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        HashGenerator hash = new HashGenerator(request.Password!, new HMACSHA512(), new byte[0]);
        byte[] UserID_Random = hash.CreateRandomID(new byte[16]);

        User u = new()
        {
            ID = UserID_Random,
            Name = request.Name,
            Email = request.Email,
            Password = hash.CreatePassword(),
            PasswordSalt = hash.HashingSalt!,
            //TODO: fluent validation for beign in enum .IsInEnum()
            UserRoleID = request.Role,
            UserInfo = new UserInfo
            {
                PhoneNumber = request.PhoneNumber
            },
        };

        User? result = await _userDbContext.CreateUser(u);

        if (result is null)
            return Result.Fail("Failed To Create User");

        return Result.Ok(new UserResult()
        {
            Info = result.UserInfo,
            Mail = result.Email,
            Name = result.Name,
            Phone = result.UserInfo!.PhoneNumber,
            UserRole = result.Role!.Name
        });

    }
}