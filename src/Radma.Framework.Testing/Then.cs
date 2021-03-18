using System;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public partial class Spec
    {
        protected Task ThenAsync(Func<Task> action)
        {
            return StatementAsync("Then {0}", action);
        }

        protected Task ThenAsync(Func<ValueTask> action)
        {
            return StatementAsync("Then {0}", action);
        }

        protected void Then(Action action)
        {
            Statement("Then {0}", action);
        }

        protected Task ThenAsync(Action action)
        {
            return StatementAsync("Then {0}", action);
        }

        protected Task ThenAsync<T>(Func<T, Task> action, T argument)
        {
            return StatementAsync("Then {0} {1}", action, argument);
        }

        protected Task ThenAsync<T>(Func<T, ValueTask> action, T argument)
        {
            return StatementAsync("Then {0} {1}", action, argument);
        }

        protected void Then<T>(Action<T> action, T argument)
        {
            Statement("Then {0} {1}", action, argument);
        }

        protected Task ThenAsync<T>(Action<T> action, T argument)
        {
            return StatementAsync("Then {0} {1}", action, argument);
        }

        protected Task ThenAsync<T1, T2>(Func<T1, T2, Task> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Then {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task ThenAsync<T1, T2>(Func<T1, T2, ValueTask> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Then {0} {1}, {2}", action, argument1, argument2);
        }

        protected void Then<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            Statement("Then {0} {1}, {2}", action, argument1, argument2);
        }

        protected Task ThenAsync<T1, T2>(Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            return StatementAsync("Then {0} {1}, {2}", action, argument1, argument2);
        }
    }
}