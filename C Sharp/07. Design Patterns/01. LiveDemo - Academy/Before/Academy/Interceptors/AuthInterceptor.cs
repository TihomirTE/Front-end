using Academy.Core.Providers;
using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interceptors
{
    public class AuthInterceptor : IInterceptor
    {
        private readonly IAuthProvider authProvider;

        public AuthInterceptor(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            if (this.authProvider.IsUserAuth())
            {
                invocation.Proceed();
            }
        }
    }
}
