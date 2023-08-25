using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name).RequiredRules().Length(5, 40);
        RuleFor(x => x.Email).RequiredRules().EmailAddress().MaximumLength(40);
        RuleFor(x => x.PhoneNumber).RequiredRules().Matches(new Regex(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$"));
        RuleFor(x => x.Password).RequiredRules().Length(10, 40);
    }
}