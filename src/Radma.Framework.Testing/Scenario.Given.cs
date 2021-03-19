using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Radma.Framework.Testing
{
    public class GivenResponse : HidesBaseMethods
    {
        internal ICollection<TestStep> _steps;

        [DebuggerStepThrough]
        public GivenResponse(TestStep given)
        {
            _steps = new List<TestStep>(new[] { given });
        }

        [DebuggerStepThrough]
        public WhenResponse When(Func<Task> when)
        {
            return new WhenResponse(_steps, when.ToStep());
        }

        [DebuggerStepThrough]
        public WhenResponse When(Action when)
        {
            return new WhenResponse(_steps, when.ToStep());
        }

        [DebuggerStepThrough]
        public WhenStep When(Func<TestStep> when)
        {
            return new WhenStep(new WhenResponse(_steps, when()));
        }

        [DebuggerStepThrough]
        public WhenStep When(Func<TestStepSync> when)
        {
            return new WhenStep(new WhenResponse(_steps, when().ToFuncStep()));
        }

        [DebuggerStepThrough]
        public GivenResponse And(Func<Task> givenAnd)
        {
            _steps.Add(givenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public GivenResponse And(Action givenAnd)
        {
            _steps.Add(givenAnd.ToStep());
            return this;
        }

        [DebuggerStepThrough]
        public GivenStep And(Func<TestStep> givenAnd)
        {
            _steps.Add(givenAnd());
            return new GivenStep(this);
        }

        [DebuggerStepThrough]
        public GivenStep And(Func<TestStepSync> givenAnd)
        {
            _steps.Add(givenAnd().ToFuncStep());
            return new GivenStep(this);
        }
    }

    public class GivenStep
    {
        private readonly GivenResponse _givenResponse;

        public GivenStep(GivenResponse givenResponse)
        {
            _givenResponse = givenResponse;
        }

        public GivenResponse WithParameters(params object[] parameters)
        {
            _givenResponse._steps.Last().Parameters = parameters;
            return _givenResponse;
        }
    }
}