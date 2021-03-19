using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public class ThenResponse : HidesBaseMethods
    {
        internal ICollection<TestStep> _steps;

        [DebuggerStepThrough]
        public ThenResponse(ICollection<TestStep> steps, TestStep then)
        {
            _steps = steps;
            _steps.Add(then);
        }

        [DebuggerStepThrough]
        public ThenResponse And(Func<Task> thenAnd)
        {
            _steps.Add(thenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public ThenResponse And(Action thenAnd)
        {
            _steps.Add(thenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public ThenStep And(Func<TestStep> thenAnd)
        {
            _steps.Add(thenAnd());
            return new ThenStep(this);
        }

        [DebuggerStepThrough]
        public ThenStep And(Func<TestStepSync> thenAnd)
        {
            _steps.Add(thenAnd().ToFuncStep());
            return new ThenStep(this);
        }



        [DebuggerStepThrough]
        public async Task Go()
        {
            foreach(var step in _steps)
            {
                await step.Func(step.Parameters);
            }
        }

        [DebuggerStepThrough]
        public void GoSync()
        {
            Task.Run(() =>
                {
                    Go().GetAwaiter().GetResult();
                })
                .GetAwaiter().GetResult();
        }
    }

    public class ThenStep
    {
        private readonly ThenResponse _thenResponse;

        public ThenStep(ThenResponse thenResponse)
        {
            _thenResponse = thenResponse;
        }

        public ThenResponse WithParameters(params object[] parameters)
        {
            _thenResponse._steps.Last().Parameters = parameters;
            return _thenResponse;
        }
    }
}