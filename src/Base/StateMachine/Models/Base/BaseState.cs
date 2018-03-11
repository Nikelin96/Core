namespace Base.StateMachine.Models.Base
{
    using System;
    using global::Base.StateMachine.Models.Interfaces;

    public abstract class BaseState<TData, TContainer> where TContainer : IStateContainer<TData>
    {
        #region ctor

        protected BaseState(TContainer container, Enum state, TData data)
            : this(container, state)
        {
            SetData(container, data);
        }

        protected BaseState(TContainer container, Enum state)
        {
            SetState(container, state);
        }

        #endregion

        protected virtual void SetState(TContainer container, Enum state)
        {
            container.State = state;
        }

        protected virtual void SetData(TContainer container, TData data)
        {
            container.Data = data;
        }
    }
}