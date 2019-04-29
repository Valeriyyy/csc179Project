using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace EDGELook.TestCases
{
    [TestFixture]
    class ChangePasswordTestClass
    {
        private LoginPage login = new LoginPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void ChangePasswordTest1()
        {
            Assert.AreEqual("Password must be at least 6 characters",login.ChangePassword("123",1));
        }
        ////Path [1,3,4]
        [TestCase]
        public void ChangePasswordTest2()
        {
            Assert.AreEqual("Not valid Connection", login.ChangePassword("mynamejeff", 1));
        }
        ////Path [1,3,5]
        [TestCase]
        public void ChangePasswordTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            login.Setup(conn);
            Assert.AreEqual("Password updated", login.ChangePassword("goodpass", 222));
        }
    }
}
