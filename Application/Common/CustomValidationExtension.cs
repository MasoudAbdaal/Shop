using FluentValidation;

public static class CustomValidationExtension
{
    public static IRuleBuilderOptions<T, TProperty> RequiredRules<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    => ruleBuilder.NotEmpty()
                  .NotNull()
                  .WithMessage("{PropertyName} must fill with suitable value");
}