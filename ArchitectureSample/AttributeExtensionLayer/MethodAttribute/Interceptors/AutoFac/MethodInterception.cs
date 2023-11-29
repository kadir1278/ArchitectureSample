using Castle.DynamicProxy;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {

        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = false;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
                isSuccess = true;
            }
            catch (FormatException)
            {
                OnException(invocation);
                throw;
            }
            catch (SecurityException)
            {
                OnException(invocation);
                throw;
            }
            catch (ValidationException)
            {
                OnException(invocation);
                throw;
            }
            catch (FluentValidation.ValidationException)
            {
                OnException(invocation);
                throw;
            }
            catch (Exception)
            {
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
                OnAfter(invocation);
            }
        }
    }
}
