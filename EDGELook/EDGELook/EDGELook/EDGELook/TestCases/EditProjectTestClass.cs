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
    class EditProjectTestClass
    {
        ProjectPage EditProj = new ProjectPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void EditProjectTest1()
        {
            Assert.AreEqual("please enter Project Number", EditProj.EditProject("","","","","",0,"",1,0));
        }
        //Path [1,3,4]
        [TestCase]
        public void EditProjectTest2()
        {
            Assert.AreEqual("Not valid connection", EditProj.EditProject("A1", "", "", "", "", 0, "", 1, 0));
        }
        //Path [1,3,5,6,7]
        [TestCase]
        public void EditProjectTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EditProj.Setup(conn);
            Assert.AreEqual("Project Changed", EditProj.EditProject("1","","","","",0,"",1,1));
        }
        //Path [1,3,5,6,8,9]
        [TestCase]
        public void EditProjectTest4()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EditProj.Setup(conn);
            Assert.AreEqual("FLAG PASSED INCORRECT VALUE", EditProj.EditProject("2", "", "", "", "", 0, "", 1, -1));
        }
        //Path [1,3,5,6,8,10,11,12,11,13,14,15]
        [TestCase]
        public void EditProjectTest5()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EditProj.Setup(conn);
            Assert.AreEqual("Duplicate Project", EditProj.EditProject("1", "", "", "", "", 0, "", 1, 0));

        }
        //Path [1,3,5,6,8,10,11,12,11,13,14,16]
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        //TEST CAN ONLY BE USED ONCE, CREATE A NEW PROJECT EVERYTIME YOU WANT TO RUN TEST
        [TestCase]
        public void EditProjectTest6()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EditProj.Setup(conn);
            Assert.AreEqual("Project Added", EditProj.EditProject("4", "", "", "", "", 0, "", 1, 0));

        }
    }
}
