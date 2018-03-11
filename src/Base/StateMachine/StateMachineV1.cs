using Base.StateMachine.Models;
using System;
using System.ComponentModel;
using System.Threading;

namespace Base.StateMachine
{
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
* Текущее состояние всегда скрыто. Иногда, бывает полезно добавить еще и переменную с предыдущим состоянием.
     
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
                    Thread.Sleep(2000);
                    SetStateNData(StateEnumV1.Enabled, dataForEnable);
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
                    Thread.Sleep(2000);
                    SetStateNData(StateEnumV1.Start, startData);
                }
                    break;
                case StateEnumV1.Start:
                {
                    Thread.Sleep(2000);
                    SetState(StateEnumV1.Start);
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
                    Thread.Sleep(2000);
                    SetState(StateEnumV1.Idle);
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
                    Thread.Sleep(2000);
                    SetState(StateEnumV1.Animating);
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
                    SetStateNData(StateEnumV1.Disabled, dataForDisable);
                }
                    break;
                case StateEnumV1.Disabled:
                    // can't switch from Disabled
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private void SetStateNData(StateEnumV1 state, DataStructureV1 data)
        {
            _stateContainer.State = state;
            _stateContainer.Data = data;
        }

        private void SetState(StateEnumV1 state)
        {
            _stateContainer.State = state;
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