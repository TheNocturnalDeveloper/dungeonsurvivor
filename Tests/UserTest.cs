using System;
using Xunit;
using Logic;
using System.Linq;


namespace Tests
{
    public class UserTest
    {
        private UserLogic logic;

        public UserTest()
        {
            logic = new UserLogic(new MemoryUserContext());
        }


        [Fact]
        public void testGetUserId()
        {
       
            logic.addUser("jake", "test");
            Assert.True(1 == logic.GetUserId("jake"));
        }


        [Fact]
        public void TestLoginSuccess()
        {
            logic.addUser("jake", "test");
            Assert.True(1 == logic.GetUserId("jake"));

        }


        [Fact]
        public void TestLoginFailure()
        {
            logic.addUser("jake", "test");
           Assert.False(2 == logic.GetUserId("jake"));

        }


        [Fact]
        public void TestAddUser()
        {
            logic.addUser("jake", "test");
            Assert.True(logic.getAllUsers().Count() == 1);
        }


        [Fact]
        public void TestRemoveUser()
        {
            logic.addUser("jake", "test");
            logic.removeUser("jake");
            Assert.True(logic.getAllUsers().Count() == 0);
        }


        [Fact]
        public void testGetAllUsers()
        {
            logic.addUser("jake", "test");
            Assert.True(logic.getAllUsers().Count() == 1);
        }


        [Fact]
        public void testGetRole()
        {
            logic.addUser("jake", "test");
            Assert.True(logic.GetRole("jake") == "normal");
        }

    }
}
