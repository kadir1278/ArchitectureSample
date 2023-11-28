using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExtensionLayer.CrossCuttingConcerns.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object isObject)
        {
            var entity = new ValidationContext<object>(isObject);
            var result = validator.Validate(entity);
            if (!result.IsValid)
                throw new ValidationException(String.Join(" - ", result.Errors));
        }
    }
}
