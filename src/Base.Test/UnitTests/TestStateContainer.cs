namespace Base.Test.UnitTests
{
    using System;
    using System.ComponentModel;
    using Base.StateMachine.Models;
    using Base.Test.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TestStateContainer
    {
        private StateEnumV1 state;

        [SetUp]
        public void Init()
        {
            // arrange
            state = StateEnumV1.Enabled;
        }

        [Test]
        public void Init_Null_ArgumentNullException()
        {
            // arrange
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => { new StateContainer<DataStructureV1>(null, null); });
        }

        [Test]
        public void Init_PrevState_Equals_State()
        {
            // arrange
            // act
            var stateContainer = new StateContainer<DataStructureV1>(state, null);

            // assert
            Assert.AreEqual(stateContainer.PrevState, stateContainer.State);
        }

        [Test]
        public void Set_PrevState_NotEqual_State()
        {
            // arrange
            var stateContainer = new StateContainer<DataStructureV1>(state, null)
                // act
                {
                    State = StateEnumV1.Start
                };

            // assert
            Assert.AreNotEqual(stateContainer.PrevState, stateContainer.State);
        }

        [Test]
        public void Set_InvalidEnum_InvalidEnumArgumentException()
        {
            // arrange
            const TestStateEnumV1 wrongState = TestStateEnumV1.Default;

            // act
            var stateContainer = new StateContainer<DataStructureV1>(state, null);

            // assert
            Assert.Throws<InvalidEnumArgumentException>(() => { stateContainer.State = wrongState; });
        }
    }
}