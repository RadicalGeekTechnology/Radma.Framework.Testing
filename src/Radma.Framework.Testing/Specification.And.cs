using System;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public partial class Specification
    {
        protected Task AndAsync(Func<Task> action)
        {
            return StatementAsync("And {0}", action);
        }

        protected Task AndAsync(Func<ValueTask> action)
        {
            return StatementAsync("And {0}", action);
        }

        protected void And(Action action)
        {
            Statement("And {0}", action);
        }

        protected Task AndAsync(Action action)
        {
            return StatementAsync("And {0}", action);
        }

        protected Task AndAsync<T>(Func<T, Task> action, T argument)
        {
            return StatementAsync("And {0} {1}", action, argument);
        }

        protected Task AndAsync<T>(Func<T, ValueTask> action, T argument)
        {
            return StatementAsync("And {0} {1}", action, argument);
        }

        protected void And<T>(Action<T> action, T argument)
        {
            Statement("And {0} {1}", action, argument);
        }

        protected Task AndAsync<T>(Action<T> action, T argument)
        {
            return StatementAsync("And {0} {1}", action, argument);
        }

        protected Task AndAsync<T1, T2>(Func<T1, T2, Task> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("And {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task AndAsync<T1, T2>(Func<T1, T2, ValueTask> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("And {0} {1}, {2}", action, argument1, argument2);
        }

        protected void And<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            Statement("And {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task AndAsync<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("And {0} {1}, {2}", action, argument1, argument2);
        }
    }
}