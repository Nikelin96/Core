namespace Base.StateMachine.Models.Interfaces
{
    using System;
    using global::Base.StateMachine.Models.Base;

    public interface IStateContainer<StateData>
    {
        StateData Data { get; set; }

        Enum State { get; set; }

        Enum PrevState { get; }

        event Action<StateContainer<StateData>> OnStateChange;
    }
}