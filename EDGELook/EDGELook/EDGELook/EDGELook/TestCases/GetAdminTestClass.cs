﻿using System;
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
    class GetAdminTestClass
    {
        private ProfilePage profile = new ProfilePage();
        private LoginPage login = new LoginPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1, 2, 3]
        [TestCase]
        public void GetAdminTest1()
        {
            Assert.AreEqual(false, profile.getAdmin(0));
        }
        //Path [1, 2, 4, 5, 6, 5, 7, 8, 9, 10]
        [TestCase]
        public void GetAdminTest2()
        {
            login.Setup(conn);
            Assert.AreEqual(true, profile.getAdmin(425));
        }
        //Path [1, 2, 4, 5, 6, 5, 7, 8, 10]
        [TestCase]
        public void GetAdminTest3()
        {
            login.Setup(conn);
            Assert.AreEqual(false, profile.getAdmin(420));
        }
    }
}
