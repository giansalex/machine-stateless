using Stateless;

namespace WorkFlowSample
{
    public enum State { Open, Assigned, Deferred, Resolved, Closed }
    public enum Trigger { Assign, Defer, Resolve, Close }
    public class MainState
    {
        private StateMachine<State, Trigger> _machine;
        public State State => _machine.State;

        public MainState()
        {
            _machine = new StateMachine<State, Trigger>(State.Open);
            _machine.Configure(State.Open)
                .Permit(Trigger.Assign, State.Assigned);

            _machine.Configure(State.Assigned)
                .SubstateOf(State.Open)
                .OnEntry(t => { })
                .Permit(Trigger.Close, State.Closed)
                .Permit(Trigger.Defer, State.Deferred);

            _machine.Configure(State.Deferred)
                .OnEntry(() => { })
                .Permit(Trigger.Assign, State.Assigned);
        }

        public void Fire(Trigger trigger)
        {
            _machine.Fire(trigger);
        }
    }
}
