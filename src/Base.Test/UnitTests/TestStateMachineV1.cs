namespace Base.Test.UnitTests
{
    using System;
    using Base.StateMachine;
    using Base.StateMachine.Models;
    using Base.StateMachine.Models.Interfaces;
    using Base.StateMachine.Models.V1;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using Rhino.Mocks;

    [TestFixture]
    public class TestStateMachineV1
    {
        [Test]
        public void Init_Null_ArgumentNullException()
        {
            // arrange
            var mockLogger = MockRepository.Mock<Serilog.ILogger>();
            var mockStateContainer = MockRepository.Mock<IStateContainer<DataStructureV1>>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => { new StateMachineV1(null, mockLogger); });
            Assert.Throws<ArgumentNullException>(() => { new StateMachineV1(mockStateContainer, null); });
        }

        [Test]
        public void GetState_ReturnsState()
        {
            // arrange
            var mockLogger = MockRepository.Mock<Serilog.ILogger>();
            const StateEnumV1 initialState = StateEnumV1.Enabled;

            var mockStateContainer = MockRepository.Mock<IStateContainer<DataStructureV1>>();
            mockStateContainer.Stub(container => container.State).Return(initialState).Repeat.Once();

            var stateMachine = new StateMachineV1(mockStateContainer, mockLogger);
            // act
            StateEnumV1 returnedState = stateMachine.GetState();

            // assert
            Assert.AreEqual(initialState, returnedState);
            mockStateContainer.AssertWasCalled(container => container.State);
            mockStateContainer.AssertWasNotCalled(container => container.PrevState);
            mockStateContainer.AssertWasNotCalled(container => container.Data);
        }

        [Test]
        public void GetData_ReturnsData()
        {
            // arrange
            var mockLogger = MockRepository.Mock<Serilog.ILogger>();
            var initialData = new DataStructureV1();

            var mockStateContainer = MockRepository.Mock<IStateContainer<DataStructureV1>>();
            mockStateContainer.Stub(container => container.Data).Return(initialData).Repeat.Once();

            var stateMachine = new StateMachineV1(mockStateContainer, mockLogger);

            // act
            DataStructureV1 returnedData = stateMachine.GetData();

            // assert
            Assert.AreEqual(initialData, returnedData);
            mockStateContainer.AssertWasNotCalled(container => container.State);
            mockStateContainer.AssertWasNotCalled(container => container.PrevState);
            mockStateContainer.AssertWasCalled(container => container.Data);
        }
    }
}