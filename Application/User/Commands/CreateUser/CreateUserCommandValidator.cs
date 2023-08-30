using System.Text.RegularExpressions;
using FluentValidation;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name).RequiredRules().Length(5, 40);
        RuleFor(x => x.Email).RequiredRules().MaximumLength(40).EmailAddress();
        RuleFor(x => x.PhoneNumber).RequiredRules().MaximumLength(15).Matches(new Regex(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$"));
        RuleFor(x => x.Password).RequiredRules().Length(10, 40);
        RuleFor(x => x.Role).IsInEnum();
    }
}