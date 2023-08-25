using FluentResults;
using MediatR;

public record GetUserQuery() : IRequest<Result<UserResult>>;
