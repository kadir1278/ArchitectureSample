using AttributeExtensionLayer.CrossCuttingConcerns.FluentValidation;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors
{
    public class ValidateOperationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        private const string _wrongTypeError = "Hatalı Validation Türü";
        public ValidateOperationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(_wrongTypeError);
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
                ValidationTool.Validate(validator, entity);
        }

        protected override void OnAfter(IInvocation invocation)
        {
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
                Console.WriteLine(entity);
        }
    }
}
