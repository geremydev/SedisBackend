using FluentValidation;
using FluentValidation.Results;
using SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LabTestHandlers;

namespace SedisBackend.Core.Application.Validators.LabTestValidators;

public sealed class CreateLabTestCommandValidator : AbstractValidator<CreateLabTestCommand>
{
    public CreateLabTestCommandValidator()
    {
        RuleFor(c => c.Labtest)
            .NotNull()
            .WithMessage("Labtest object is null.")
            .DependentRules(() =>
            {
                RuleFor(c => c.Labtest.TestName)
                    .NotEmpty()
                    .WithMessage("TestName cannot be empty.")
                    .MaximumLength(60)
                    .WithMessage("TestName must not exceed 60 characters.");

                RuleFor(c => c.Labtest.TestCode)
                    .NotEmpty()
                    .WithMessage("TestCode cannot be empty.")
                    .MaximumLength(60)
                    .WithMessage("TestCode must not exceed 60 characters.");
            });
    }

    public override ValidationResult Validate(ValidationContext<CreateLabTestCommand> context)
    {
        return context.InstanceToValidate.Labtest is null
            ? new ValidationResult(new[] { new ValidationFailure("LabtestForCreationDto",
            "LabtestForCreationDto object is null") })
            : base.Validate(context);
    }
}
