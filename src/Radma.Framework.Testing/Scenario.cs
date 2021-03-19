using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public class Scenario : HidesBaseMethods
    {
        [DebuggerStepThrough]
        public static GivenResponse Given(Func<Task> given)
        {
            return new GivenResponse(given.ToStep());
        }

        [DebuggerStepThrough]
        public static GivenResponse Given(Action given)
        {
            return new GivenResponse(given.ToStep());
        }

        [DebuggerStepThrough]
        public static GivenStep Given(Func<TestStep> given)
        {
            return new GivenStep(new GivenResponse(given()));
        }

        [DebuggerStepThrough]
        public static GivenStep Given(Func<TestStepSync> given)
        {
            return new GivenStep(new GivenResponse(given().ToFuncStep()));
        }
    }
    
    public class TestStep
    {
        public Func<IEnumerable<object>, Task> Func { get; set; }
        public IEnumerable<object> Parameters { get; internal set; }
    }

    public class TestStepSync
    {
        public Action<IEnumerable<object>> Action { get; set; }
        public IEnumerable<object> Parameters { get; internal set; }
    }

    internal static class Helper
    {
        [DebuggerStepThrough]
        private static Func<IEnumerable<object>, Task> ToStepFunc(this Action action)
        {
            return new Func<IEnumerable<object>, Task>(i =>
            {
                action();
                return Task.CompletedTask;
            });
        }

        [DebuggerStepThrough]
        public static TestStep ToFuncStep(this TestStepSync syncStep)
        {
            return new TestStep
            {
                Func = p =>
                {
                    syncStep.Action(p);
                    return Task.CompletedTask;
                },
                Parameters = syncStep.Parameters
            };
        }

        [DebuggerStepThrough]
        public static TestStep ToStep(this Func<Task> func)
        {
            return new TestStep
            {
                Func = p => func(),
                Parameters = new object[0]
            };
        }

        [DebuggerStepThrough]
        public static TestStep ToStep(this Action action)
        {
            return new TestStep
            {
                Func = action.ToStepFunc(),
                Parameters = new object[0]
            };
        }
    }
}