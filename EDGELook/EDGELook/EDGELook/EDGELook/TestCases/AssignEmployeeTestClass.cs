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
    class AssignEmployeeTestClass
    {
        ProjectPage AProj = new ProjectPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void AssignEmployeeTest1()
        {
            Assert.AreEqual("Not valid connection", AProj.AssignEmployee(2, "Chris", "Williams", "A899"));
        }

        //Path [1, 3, 4, 5, 4, 6, 7, 8, 7, 9, 10, 11]
        [TestCase]
        public void AssignEmployeeTest2()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            AProj.Setup(conn);
            Assert.AreEqual("Not enough hours available to be added to project.", AProj.AssignEmployee(40,"Iris","Ivy","E349"));
        }
        //Path [1, 3, 4, 5, 4, 6, 7, 8, 7, 9, 10, 12, 13, 14, 13, 15, 16, 17
        [TestCase]
        public void AssignEmployeeTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            AProj.Setup(conn);
            Assert.AreEqual("Duplicate Employee on Project",AProj.AssignEmployee(4,"Jane","Doe","F163"));
        }
        //Path [1, 3, 4, 5, 4, 6, 7, 8, 7, 9, 10, 12, 13, 14, 13, 15, 16, 18]
        //TEST CAN ONLY BE RUN LIMITED AMOUNT OF TIME BECAUSE EMPLOYEES MAY RUN OUT OF HOURS DUE TO EXCESSIVE RUNS
        //CHECK HOW MANY HOURS EMPLOYEES HAVE BEFORE ADDING THEM TO A PRODJECT THROUGH THE TEST
        [TestCase]
        public void AssignEmployeeTest4()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            AProj.Setup(conn);
            Assert.AreEqual("Employee Added to project", AProj.AssignEmployee(15, "Iris", "Ivy", "F163"));
        }
    }
}
