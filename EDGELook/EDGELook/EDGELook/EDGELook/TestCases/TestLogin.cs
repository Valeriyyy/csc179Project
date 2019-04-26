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
    class TestLogin
    {
        private LoginPage login = new LoginPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void LoginTest1()
        {
            Assert.AreEqual(-1, login.Login("", ""));
        }
        //Path [1, 3, 4, 5, 4, 6, 7, 9]
        [TestCase]
        public void LoginTest2()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            login.Setup(conn);
            Assert.AreEqual(null, login.Login("sevenwonders@yahoo.com", "password"));
        }
        //Path [1, 3, 4, 5, 4, 6, 8, 9]
        [TestCase]
        public void LoginTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            login.Setup(conn);
            Assert.AreEqual(444, login.Login("tester@yahoo.com", "pssword"));
        }
    }
}
