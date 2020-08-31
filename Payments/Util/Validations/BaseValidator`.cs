using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Payments.Util.Validations
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator() : base()
        {
        }

        public override FluentValidation.Results.ValidationResult Validate(ValidationContext<T> context)
        {
            IList<ValidationFailure> validationFailures = base.Validate(context).Errors ?? new List<ValidationFailure>();
            ValidatePropertyAsync(context, validationFailures);
            return new FluentValidation.Results.ValidationResult(validationFailures);
        }

        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            IList<ValidationFailure> validationFailures = (await base.ValidateAsync(context)).Errors ?? new List<ValidationFailure>();
            if (cancellation.IsCancellationRequested)
            {
                ValidatePropertyAsync(context, validationFailures);
            }
            return new FluentValidation.Results.ValidationResult(validationFailures);
        }


        public virtual void ValidatePropertyAsync(ValidationContext<T> context, IList<ValidationFailure> validationFailures)
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetCustomAttributes<ValidationAttribute>(true)?.Count() > 0);
            foreach (var propertie in properties)
            {
                var validationAttributes = propertie.GetCustomAttributes<ValidationAttribute>(true);
                foreach (var validationAttribute in validationAttributes)
                {
                    var result = validationAttribute.GetValidationResult(propertie.GetValue(context.InstanceToValidate), new System.ComponentModel.DataAnnotations.ValidationContext(context.InstanceToValidate));
                    if (result != null)
                    {
                        validationFailures.Add(new ValidationFailure(propertie.Name, result.ErrorMessage));
                    }
                }
            }
        }


    }
}
