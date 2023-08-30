using FluentResults;
using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
 where TResponse : ResultBase
 where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest> validator) => _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //TODO: Unable to resolve service for type 'FluentValidation.IValidator`1[CreateUserCommand]' while
        // attempting to activate'ValidationBehavior`2[CreateUserCommand,FluentResults.Result`1[UserResult]]'
        var validationsResult = await _validator!.ValidateAsync(request);

        if (validationsResult.IsValid)
            return await next();

        return (dynamic)Result.Fail(validationsResult.Errors.ConvertAll(x => new Error(x.ErrorMessage).CausedBy(x.PropertyName)));
    }
}