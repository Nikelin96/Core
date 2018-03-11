namespace Base.StateMachine.Models.V1.States
{
    using System;
    using System.Threading;
    using global::Base.StateMachine.Models.Base;
    using global::Base.StateMachine.Models.Interfaces;

    public class StateStart : BaseState<DataStructureV1, IStateContainer<DataStructureV1>>
    {
        public StateStart(IStateContainer<DataStructureV1> stateContainer, DataStructureV1 data)
            : base(stateContainer, StateEnumV1.Start, data)
        {
            Thread.Sleep(2000);
        }

        public StateStart(IStateContainer<DataStructureV1> stateContainer)
            : base(stateContainer, StateEnumV1.Start)
        {
            Thread.Sleep(1000);
        }

        // override logic here, perform some logic
        // that depends on previous state
        protected override void SetData(IStateContainer<DataStructureV1> container, DataStructureV1 data)
        {
            base.SetData(container, data);
        }

        protected override void SetState(IStateContainer<DataStructureV1> container, Enum state)
        {
            base.SetState(container, state);
        }
    }
}