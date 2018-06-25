using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Epic_Construction_21402733
{
    public partial class Staff : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        private int StaffId;
        private string StaffFName;
        private string StaffLName;
        private string StaffUsername;
        private string StaffPassword;
        private string StaffEmail;
        private int StaffVoted;
        private string StaffVoteTime;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from StaffTable where StaffUsername='" + LoginStaffUsername.Text + "'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StaffId = Convert.ToInt32(reader["StaffId"].ToString());
                StaffFName = reader["StaffFName"].ToString();
                StaffLName = reader["StaffLName"].ToString();
                StaffUsername = reader["StaffUsername"].ToString();
                StaffPassword = reader["StaffPassword"].ToString();
                StaffEmail = reader["StaffEmail"].ToString();
                StaffVoted = Convert.ToInt32(reader["Voted"].ToString());
                //StaffVoteTime = reader["StaffVoteTime"].ToString();
            }
            reader.Close();

            Session["StaffLogin"] = StaffFName;

            if (LoginStaffUsername.Text != "" & LoginStaffPassword.Text != "")
            {
                if (StaffVoted != 0)
                {
                    LabelLoginVoted.Text = Session["StaffLogin"].ToString() + " has already voted and cannot log in.";
                }

                else
                {
                    string queryText = @"SELECT Count(*) FROM StaffTable WHERE StaffUsername = @Username AND StaffPassword = @Password";

                    using (SqlCommand StaffLogincmd = new SqlCommand(queryText, con))
                    {
                        StaffLogincmd.Parameters.AddWithValue("@Username", LoginStaffUsername.Text);
                        StaffLogincmd.Parameters.AddWithValue("@Password", LoginStaffPassword.Text);
                        int result = (int)StaffLogincmd.ExecuteScalar();
                        if (result > 0)
                        {
                            Response.Redirect("Voting.aspx");
                        }
                    }
                }  
            }
        }

        protected void RegisterStaffButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT StaffUsername FROM StaffTable", con);
            con.Open();
            string value = command.ExecuteScalar() as string;
  
            if (RegisterStaffUsername.Text.Equals(value))
            {
                LabelUsernameExists.Text = "Username already exists, please choose another.";
            }
            else
            {
                SqlCommand StaffRegcmd = new SqlCommand("insert into StaffTable(StaffFName, StaffLName, StaffUsername, StaffPassword, StaffEmail, Voted) values (@FirstName, @LastName, @Username, @Password, @Email, @Voted)", con);
                StaffRegcmd.Parameters.AddWithValue("FirstName", RegisterStaffFirstName.Text);
                StaffRegcmd.Parameters.AddWithValue("LastName", RegisterStaffLastName.Text);
                StaffRegcmd.Parameters.AddWithValue("Username", RegisterStaffUsername.Text);
                StaffRegcmd.Parameters.AddWithValue("Password", RegisterStaffPassword.Text);
                StaffRegcmd.Parameters.AddWithValue("Email", RegisterStaffEmail.Text);
                StaffRegcmd.Parameters.AddWithValue("@Voted", "0");
                StaffRegcmd.ExecuteNonQuery();

                RegisterStaffFirstName.Text = "";
                RegisterStaffLastName.Text = "";
                RegisterStaffUsername.Text = "";
                RegisterStaffPassword.Text = "";
                RegisterStaffEmail.Text = "";
                RegisterStaffSuccess.Text = "Registration Successful";
            }
        }
    }
}