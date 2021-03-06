﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace EDGELook
{
    class EmployeePage
    {
        private MySqlConnection conn;
        private int? eID;

        public void Setup(MySqlConnection newConn)
        {
            conn = newConn;
        }
        public void SetID(String newEmpID)
        {
            eID = int.Parse(newEmpID);
        }
        public void GetHours(TextBox hoursBox)
        {
            conn.Open();
            String getHours = "SELECT hoursAvail FROM Employee WHERE employeeID = '" + eID + "';";
            MySqlCommand cmd = new MySqlCommand(getHours, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hoursBox.Text = reader.GetString("hoursAvail");
            }
            conn.Close();
        }
        public void GetEmail(TextBox emailBox)
        {
            conn.Open();
            String getEmail = "SELECT email FROM Employee WHERE employeeID = '" + eID + "';";
            MySqlCommand cmd = new MySqlCommand(getEmail, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emailBox.Text = reader.GetString("email");
            }
            conn.Close();
        }
        public void GetPhone(TextBox phoneBox)
        {
            conn.Open();
            String getPhone = "SELECT phone FROM Employee WHERE employeeID = '" + eID + "';";
            MySqlCommand cmd = new MySqlCommand(getPhone, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                phoneBox.Text = reader.GetString("phone");
            }
            conn.Close();
        }
        public void ListProjects(DataGridView projectsGrid)
        {
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select p.prjNo, p.Description from Project p, WorksOn w where p.prjNo = w.prjNo AND w.employeeID = '" + eID + "';", conn);
            DataTable table = new DataTable();
            da.Fill(table);
            projectsGrid.DataSource = table;
            conn.Close();
        }
        public void NameDisplay(Label employeeName)
        {
            conn.Open();
            String getName = "SELECT fname, lname FROM Employee WHERE employeeID = '" + eID + "';";
            MySqlCommand cmd = new MySqlCommand(getName, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employeeName.Text = reader.GetString("fname") + " " + reader.GetString("lname");
            }
            conn.Close();
        }

        public void ListEmployees(DataGridView employeeGrid, int? eID)
        {
            conn.Open();

            MySqlDataAdapter da = new MySqlDataAdapter("Select employeeID, fname, lname from Employee ;", conn); 
            DataTable table = new DataTable();
            da.Fill(table);
            employeeGrid.DataSource = table;
            conn.Close();
            employeeGrid.Columns[0].Width = 50;
            employeeGrid.Columns[1].Width = 125;
            employeeGrid.Columns[2].Width = 125;
        }
    }
}
