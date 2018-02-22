namespace Base.StateMachine.Models
{
    using System;

    public class StateContainer<StateData>
    {
        #region props
        // enum type for verification in runtime
        private readonly Type EnumType;

        public StateData Data { get; set; }

        private Enum _prevState { get; set; }

        private Enum _currentState { get; set; }


        public Enum State
        {
            get => _currentState;
            set
            {
                Type newStateType = value.GetType();
                if (newStateType == EnumType)
                {
                    _currentState = value;
                }
                else throw new ArgumentException($"{newStateType} does not match container type: {EnumType}");
            }
        }

        #endregion

        #region ctor
        public StateContainer(Type enumType, StateData stateData)
        {
            EnumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
            Data = stateData;
        }
        #endregion
    }
}
