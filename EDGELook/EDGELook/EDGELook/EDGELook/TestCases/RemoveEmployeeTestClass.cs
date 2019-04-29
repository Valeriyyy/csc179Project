using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace EDGELook.TestCases
{
    [TestFixture]
    class RemoveEmployeeTestClass
    {
        ProjectPage EmpProj = new ProjectPage();
        private MySqlConnection conn;
        private DBConn dbconn;

        //Path [1,2]
        [TestCase]
        public void RemoveEmployeeTest1()
        {
            Assert.AreEqual("Not valid connection",EmpProj.RemoveEmployee("Chris","Williams","A899"));
        }

        //Path [1, 3, 4, 5, 4, 6, 7, 8, 7, 9, 10, 11]
        [TestCase]
        public void RemoveEmployeeTest2()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EmpProj.Setup(conn);
            Assert.AreEqual("Project Leader cannot be removed.", EmpProj.RemoveEmployee("Iris", "Ivy", "A899"));
        }
        //Path [1, 3, 4, 5, 4, 6, 7, 8, 7, 9, 10, 12, 13, 14, 13, 15, 16, 17, 16, 18]
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        //REMOVES EMPLOYEE FROM ALL PROJECTS IN THE WORKSON TABLE
        [TestCase]
        public void RemoveEmployeeTest3()
        {
            dbconn = new DBConn();
            conn = dbconn.Dbsetup();
            EmpProj.Setup(conn);
            Assert.AreEqual("Employee removed from project", EmpProj.RemoveEmployee("Chris", "Williams", "A899"));

        }
    }
}
