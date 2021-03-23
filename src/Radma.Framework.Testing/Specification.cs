using System;
using System.Linq;
using Xunit.Abstractions;

namespace Radma.Framework.Testing
{
    public partial class Specification
    {
        private readonly ITestOutputHelper _output;

        public Specification(ITestOutputHelper output)
        {
            _output = output;
        }

        protected string GetLogMessage(string format, Delegate @delegate, params object[] arguments)
        {
            var name = @delegate.Method.Name.Replace('_', ' ');
            name = name[..1].ToUpper() + name[1..].ToLower();
            return string.Format(format, arguments.Prepend(name).ToArray());
        }
    }
}