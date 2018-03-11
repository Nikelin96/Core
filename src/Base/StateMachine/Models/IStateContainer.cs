namespace Base.StateMachine.Models
{
    using System;

    public interface IStateContainer<StateData>
    {
        StateData Data { get; set; }

        Enum State { get; set; }

        Enum PrevState { get; }

        event Action<StateContainer<StateData>> OnStateChange;
    }
}