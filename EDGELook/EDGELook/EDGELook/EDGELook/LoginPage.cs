using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGELook
{
    class LoginPage
    {
        private string email;
        private string password;
        private MySqlConnection conn;
        private int? eID;

        public int? Login (string email, string password)
        {
            if(conn == null)
            {
                return -1;
            }        
            conn.Open();
           
            string getLogin = "SELECT employeeID FROM Employee WHERE email = '" + email + "' AND pssword = '" + password + "';";
			MySqlCommand cmd = new MySqlCommand(getLogin, this.conn);
			MySqlDataReader reader = cmd.ExecuteReader();		         
            while (reader.Read())
            {
                eID = reader.GetInt16("employeeID");
            }
            if (eID == null)
            {
                Console.WriteLine("Not valid login");
            }
            else
                Console.WriteLine("Logged in");
            conn.Close();
            return eID;
        }
        public void Setup(MySqlConnection newConn)
        {
            conn = newConn;
        }
        //This only works after the user logs in and has a connection set up
        public string ChangePassword(string newPassword, int? eID)
        {          
            if (newPassword.Length < 6)
            {
                return "Password must be at least 6 characters";
            }
            else
            {
				if(conn == null)
            {
                return "Not valid Connection";
            }
                conn.Open();
                string setPassword = "UPDATE EMPLOYEE SET pssword = '" + newPassword + "' WHERE employeeID = " + eID + ";";
                MySqlCommand cmd = new MySqlCommand(setPassword, conn);
                Console.WriteLine(cmd.ExecuteNonQuery());
                conn.Close();
				return "Password updated";
            }
        }
    }
}
