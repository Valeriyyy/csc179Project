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
    class EditVacationTest
    {
        ProfilePage profile = new ProfilePage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void EditVacationTest1()
        {
            Assert.AreEqual("Not valid connection", profile.EditVacation("2020-1-20", "2020-2-20", 1));
        }
        //Path [1, 3, 4, 5, 4, 6, 7]
        [TestCase]
        public void EditVacationTest2()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            profile.Setup(conn, 425);
            Assert.AreEqual("Duplicate Vacation", profile.EditVacation("0000-00-00", "0000-00-00", 425));
        }
        //Path [1, 3, 4, 5, 4, 6, 8]
        //TEST CAN BE USED ONLY ONCE, FOR ANOTHER TEST USE, CREATE A NEW DATE OR ENTER DIFFERENT EID
        [TestCase]
        public void EditVacationTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            profile.Setup(conn, 425);
            Assert.AreEqual("Vacation days Created", profile.EditVacation("2020-1-20", "2020-3-20", 425));
        }

    }
}
