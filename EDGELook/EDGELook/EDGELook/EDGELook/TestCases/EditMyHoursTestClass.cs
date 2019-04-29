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
    class EditMyHoursTestClass
    {
        ProfilePage profile = new ProfilePage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void EditMyHoursTest1()
        {
            Assert.AreEqual("Not valid connection",profile.EditMyHours(1,1));
        }
        //Path [1,3,5]
        [TestCase]
        public void EditMyHoursTest2()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            profile.Setup(conn, 420);
            Assert.AreEqual("Invalid Input",profile.EditMyHours(-1000,420));
        }
        //Path [1,3,4]
        [TestCase]
        public void EditMyHoursTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            profile.Setup(conn, 420);
            Assert.AreEqual("Hours Updated", profile.EditMyHours(2, 420));
        }
    }
}
