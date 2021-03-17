using System;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public partial class Spec
    {
         private async Task StatementCoreAsync(string message, Func<Task> action)
        {
            _testOutput.WriteLine(message);

            try
            {
                await action();
                _testOutput.WriteLine("...done");
            }
            catch (Exception e)
            {
                _testOutput.WriteLine($"Error - {e.Message}");
                throw;
            }
        }

        private async Task StatementCoreAsync(string message, Action action)
        {
            await StatementCoreAsync(message, () =>
            {
                action();
                return Task.CompletedTask;
            });
        }

        private void StatementCore(string message, Action action)
        {
            StatementCoreAsync(message, action).GetAwaiter().GetResult();
        }

        protected Task StatementAsync(string messageFormat, Func<Task> action)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action),
                action);
        }

        protected Task StatementAsync(string messageFormat, Func<ValueTask> action)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action),
                () => action().AsTask());
        }

        protected void Statement(string messageFormat, Action action)
        {
            StatementCore(
                GetLogMessage(messageFormat, action),
                action);
        }

        protected Task StatementAsync(string messageFormat, Action action)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action),
                action);
        }

        protected Task StatementAsync<T>(string messageFormat, Func<T, Task> action, T argument)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument),
                () => action(argument));
        }

        protected Task StatementAsync<T>(string messageFormat, Func<T, ValueTask> action, T argument)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument),
                () => action(argument).AsTask());
        }

        protected void Statement<T>(string messageFormat, Action<T> action, T argument)
        {
            StatementCore(
                GetLogMessage(messageFormat, action, argument),
                () => action(argument));
        }

        protected Task StatementAsync<T>(string messageFormat, Action<T> action, T argument)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument),
                () => action(argument));
        }

        protected Task StatementAsync<T1, T2>(string messageFormat, Func<T1, T2, Task> action, T1 argument1, T2 argument2)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument1, argument2),
                () => action(argument1, argument2));
        }

        protected Task StatementAsync<T1, T2>(string messageFormat, Func<T1, T2, ValueTask> action, T1 argument1, T2 argument2)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument1, argument2),
                () => action(argument1, argument2).AsTask());
        }

        protected void Statement<T1, T2>(string messageFormat, Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            StatementCore(
                GetLogMessage(messageFormat, action, argument1, argument2),
                () => action(argument1, argument2));
        }

        protected Task StatementAsync<T1, T2>(string messageFormat, Action<T1, T2> action, T1 argument1, T2 argument2)
        {
            return StatementCoreAsync(
                GetLogMessage(messageFormat, action, argument1, argument2),
                () => action(argument1, argument2));
        }
        
    }
}