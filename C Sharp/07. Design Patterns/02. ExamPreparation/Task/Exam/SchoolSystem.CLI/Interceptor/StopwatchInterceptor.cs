using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;
using System.Diagnostics;

namespace SchoolSystem.Cli.Interceptor
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly IWriter writer;
        private readonly Stopwatch stopwatch;

        public StopwatchInterceptor(IWriter writer)
        {
            this.writer = writer;
            this.stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();

            this.writer.WriteLine($"Calling method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name}...");

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            this.writer.WriteLine($@"Total execution time for method {invocation.Request.Method.Name} of type 
                {invocation.Request.Method.DeclaringType.Name} is {stopwatch.Elapsed.Milliseconds} milliseconds.");
        }
    }
}
