using Castle.DynamicProxy;
using CoreLayer.Utilities.Results.Concrete;
using System.Security;
using System.Text.Json;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {

        protected virtual void OnBefore(IInvocation ınvocation) { }
        protected virtual void OnException(IInvocation ınvocation) { }
        protected virtual void OnFinally(IInvocation ınvocation) { }
        protected virtual void OnAfter(IInvocation ınvocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = false;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
                isSuccess = true;
            }
            catch (SecurityException)
            {
                OnException(invocation);
                throw;
            }
            catch (FormatException)
            {
                OnException(invocation);
            }
            catch (Exception)
            {
                OnException(invocation);
            }
            finally
            {
                if (isSuccess) OnFinally(invocation);
                OnAfter(invocation);
            }
        }
    }
}
