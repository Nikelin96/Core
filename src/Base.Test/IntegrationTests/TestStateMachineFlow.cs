//namespace Base.Test.IntegrationTests
//{
//    using System;
//    using Base.StateMachine;
//    using Base.StateMachine.Models;
//    using NUnit.Framework;
//
//    [TestFixture]
//    public class TestStateMachineFlow
//    {
//        private StateEnumV1 state;
//
//        [SetUp]
//        public void Init()
//        {
//            // arrange
//            state = StateEnumV1.Enabled;
//        }
//
//        [Test]
//        public void Test()
//        {
//            // arrange
//            var data = new DataStructureV1();
//            var stateContainer = new StateContainer<DataStructureV1>(state, data);
//            var stateMachine = new StateMachineV1(stateContainer);
//
//            // act
//            stateMachine.State_Start(data);
//
//            // assert
//            Assert.AreEqual(state, stateMachine.GetState());
//        }
//    }
//}