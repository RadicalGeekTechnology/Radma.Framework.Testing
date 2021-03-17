using System;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public partial class Spec
    {
        protected Task WhenAsync(Func<Task> action)
        {
            return StatementAsync("When {0}", action);
        }

        protected Task WhenAsync(Func<ValueTask> action)
        {
            return StatementAsync("When {0}", action);
        }

        protected void When(Action action)
        {
            Statement("When {0}", action);
        }

        protected Task WhenAsync(Action action)
        {
            return StatementAsync("When {0}", action);
        }

        protected Task WhenAsync<T>(Func<T, Task> action, T argument)
        {
            return StatementAsync("When {0} {1}", action, argument);
        }

        protected Task WhenAsync<T>(Func<T, ValueTask> action, T argument)
        {
            return StatementAsync("When {0} {1}", action, argument);
        }

        protected void When<T>(Action<T> action, T argument)
        {
            Statement("When {0} {1}", action, argument);
        }

        protected Task WhenAsync<T>(Action<T> action, T argument)
        {
            return StatementAsync("When {0} {1}", action, argument);
        }

        protected Task WhenAsync<T1, T2>(Func<T1, T2, Task> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("When {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task WhenAsync<T1, T2>(Func<T1, T2, ValueTask> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("When {0} {1}, {2}", action, argument1, argument2);
        }

        protected void When<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            Statement("When {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task WhenAsync<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("When {0} {1}, {2}", action, argument1, argument2);
        }
    }
}