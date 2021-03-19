using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public class WhenResponse : HidesBaseMethods
    {
        internal ICollection<TestStep> _steps;

        [DebuggerStepThrough]
        public WhenResponse(ICollection<TestStep> steps, TestStep when)
        {
            _steps = steps; 
            _steps.Add(when);
        }

        [DebuggerStepThrough]
        public ThenResponse Then(Func<Task> then)
        {
            return new ThenResponse(_steps, then.ToStep());
        }

        [DebuggerStepThrough]
        public ThenResponse Then(Action then)
        {
            return new ThenResponse(_steps, then.ToStep());
        }

        [DebuggerStepThrough]
        public ThenStep Then(Func<TestStep> then)
        {
            return new ThenStep(new ThenResponse(_steps, then()));
        }

        [DebuggerStepThrough]
        public ThenStep Then(Func<TestStepSync> then)
        {
            return new ThenStep(new ThenResponse(_steps, then().ToFuncStep()));
        }

        [DebuggerStepThrough]
        public WhenResponse And(Func<Task> whenAnd)
        {
            _steps.Add(whenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public WhenResponse And(Action whenAnd)
        {
            _steps.Add(whenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public WhenStep And(Func<TestStep> whenAnd)
        {
            _steps.Add(whenAnd());
            return new WhenStep(this);
        }

        [DebuggerStepThrough]
        public WhenStep And(Func<TestStepSync> whenAnd)
        {
            _steps.Add(whenAnd().ToFuncStep());
            return new WhenStep(this);
        }
    }
    
    public class WhenStep
    {
        private readonly WhenResponse _whenResponse;

        public WhenStep(WhenResponse whenResponse)
        {
            _whenResponse = whenResponse;
        }

        public WhenResponse WithParameters(params object[] parameters)
        {
            _whenResponse._steps.Last().Parameters = parameters;
            return _whenResponse;
        }
    }
}