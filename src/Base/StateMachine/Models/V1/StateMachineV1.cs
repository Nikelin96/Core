namespace Base.StateMachine.Models.V1
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using global::Base.StateMachine.Models.Base;
    using global::Base.StateMachine.Models.Interfaces;
    using global::Base.StateMachine.Models.V1.States;
    using Serilog;

    public class StateMachineV1
    {
        private readonly IStateContainer<DataStructureV1> _stateContainer;

        private readonly ILogger _logger;

        public StateMachineV1(IStateContainer<DataStructureV1> stateContainer, ILogger logger)
        {
            _stateContainer = stateContainer ?? throw new ArgumentNullException(nameof(stateContainer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _stateContainer.OnStateChange += OnStateChange;
        }

        /**
        * Текущее состояние.
        * Есть переменная с предыдущим состоянием.
             
        * Все смены состояний происходят только через вызов методов state<название состояния>().
        * В них сперва может быть выполнена логика для выхода из КОНКРЕТНОГО предыдущего состояния в КОНКРЕТНОЕ новое.
        * После чего выполняется setState(newValue) и специфическая для состояния логика.
                
        * Обработчики событий делают только то, что можно в текущем состоянии.
        */

        public void State_Enabled(DataStructureV1 dataForEnable)
        {
            switch (_stateContainer.PrevState)
            {
                case StateEnumV1.Enabled:
                    // can't switch from Enabled
                    break;
                case StateEnumV1.Start:
                    // can't switch from Start
                    break;
                case StateEnumV1.Idle:
                    // can't switch from Idle
                    break;
                case StateEnumV1.Animating:
                {
                    new StateEnabled(_stateContainer, dataForEnable);
                }
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void State_Start(DataStructureV1 startData)
        {
            switch (_stateContainer.PrevState)
            {
                case StateEnumV1.Enabled:
                {
                    new StateStart(_stateContainer, startData);
                }
                    break;
                case StateEnumV1.Start:
                {
                    new StateStart(_stateContainer);
                }
                    break;
                case StateEnumV1.Idle:
                    // can't switch from Idle
                    break;
                case StateEnumV1.Animating:
                    // can't switch from Animating
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void State_Idle()
        {
            switch (_stateContainer.PrevState)
            {
                case StateEnumV1.Enabled:
                    // can't switch from Enabled
                    break;
                case StateEnumV1.Start:
                {
                    new StateIdle(_stateContainer);
                }
                    break;
                case StateEnumV1.Idle:
                    // can't switch from Idle
                    break;
                case StateEnumV1.Animating:
                    // can't switch from Animating
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void State_Animating()
        {
            switch (_stateContainer.PrevState)
            {
                case StateEnumV1.Enabled:
                    // can't switch from Enabled
                    break;
                case StateEnumV1.Start:
                    // can't switch from Start
                    break;
                case StateEnumV1.Idle:
                {
                    new StateAnimating(_stateContainer);
                }
                    break;
                case StateEnumV1.Animating:
                    // can't switch from Animating  
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void State_Disabled(DataStructureV1 dataForDisable)
        {
            switch (_stateContainer.PrevState)
            {
                case StateEnumV1.Enabled:
                    // can't switch from Enabled
                    break;
                case StateEnumV1.Start:
                    // can't switch from Start
                    break;
                case StateEnumV1.Idle:
                    // can't switch from Idle
                    break;
                case StateEnumV1.Animating:
                {
                    Thread.Sleep(2000);
                    new StateDisabled(_stateContainer, dataForDisable);
                }
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public DataStructureV1 GetData()
        {
            return _stateContainer.Data;
        }

        public StateEnumV1 GetState()
        {
            return (StateEnumV1) _stateContainer.State;
        }

        private void OnStateChange(IStateContainer<DataStructureV1> container)
        {
            _logger.Information($"Previous State is: {container.PrevState}");
            _logger.Information($"Current State is: {container.State}");
            switch (container.State)
            {
                case StateEnumV1.Enabled:
                {
                    _logger.Information($"Message: {container.Data?.StringValue}");
                }
                    break;
                case StateEnumV1.Start:
                {
                    _logger.Information($"Message: {container.Data?.StringValue}");
                }
                    break;
                case StateEnumV1.Idle:
                {
                }
                    break;
                case StateEnumV1.Animating:
                {
                }
                    break;
                case StateEnumV1.Disabled:
                {
                    _logger.Information($"Message: {container.Data?.StringValue}");
                }
                    break;
            }
        }
    }
}