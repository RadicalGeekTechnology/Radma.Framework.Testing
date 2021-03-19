using System;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public partial class Specification
    {
        protected Task GivenAsync(Func<Task> action)
        {
            return StatementAsync("Given {0}", action);
        }

        protected Task GivenAsync(Func<ValueTask> action)
        {
            return StatementAsync("Given {0}", action);
        }

        protected void Given(Action action)
        {
            Statement("Given {0}", action);
        }

        protected Task GivenAsync(Action action)
        {
            return StatementAsync("Given {0}", action);
        }

        protected Task GivenAsync<T>(Func<T, Task> action, T argument)
        {
            return StatementAsync("Given {0} {1}", action, argument);
        }

        protected Task GivenAsync<T>(Func<T, ValueTask> action, T argument)
        {
            return StatementAsync("Given {0} {1}", action, argument);
        }

        protected void Given<T>(Action<T> action, T argument)
        {
            Statement("Given {0} {1}", action, argument);
        }

        protected Task GivenAsync<T>(Action<T> action, T argument)
        {
            return StatementAsync("Given {0} {1}", action, argument);
        }

        protected Task GivenAsync<T1, T2>(Func<T1, T2, Task> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Given {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task GivenAsync<T1, T2>(Func<T1, T2, ValueTask> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Given {0} {1}, {2}", action, argument1, argument2);
        }

        protected void Given<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            Statement("Given {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task GivenAsync<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Given {0} {1}, {2}", action, argument1, argument2);
        }
    }
}