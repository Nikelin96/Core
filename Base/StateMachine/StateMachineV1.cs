using Base.StateMachine.Models;
using System;

namespace Base.StateMachine
{
    public class StateMachineV1
    {
        private StateContainer<DataStructureV1> StateContainer { get; set; }


        public StateMachineV1(StateContainer<DataStructureV1> initialState)
        {
            StateContainer = initialState;
        }

        public void State1(StateEnumV1 state)
        {

            switch (state)
            {
                case StateEnumV1.Switch1FromState3NState5:
                    break;
                case StateEnumV1.Switch2FromState1NState5:
                    StateContainer.State = state;
                    break;
                case StateEnumV1.Switch3FromState1NState4:
                    // do something
                    var s = 1 + 2 + 3;
                    StateContainer.State = state;
                    break;
                case StateEnumV1.Switch4FromState1NState3:
                    break;
                case StateEnumV1.Switch5FromState1NState2:
                    break;
                default:
                    break;
            }
        }

    }
}
