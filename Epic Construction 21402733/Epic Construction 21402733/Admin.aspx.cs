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
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        private int AdminId;
        private string AdminFName;
        private string AdminLName;
        private string AdminUsername;
        private string AdminPassword;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LoginAdminButton_Click(object sender, EventArgs e)
        {  
            SqlCommand cmd = new SqlCommand("select * from AdminTable where AdminUsername='" + LoginAdminUsername.Text + "'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
 
            while (reader.Read())
            {
                AdminId = Convert.ToInt32(reader["AdminId"].ToString());
                AdminFName = reader["AdminFName"].ToString();
                AdminLName = reader["AdminLName"].ToString();
                AdminUsername = reader["AdminUsername"].ToString();
                AdminPassword = reader["AdminPassword"].ToString();
            }
            reader.Close();

            Session["AdminLogin"] = AdminFName + " " + AdminLName;

            if (LoginAdminUsername.Text != "" & LoginAdminPassword.Text != "")
            {
                string queryText = @"SELECT Count(*) FROM AdminTable WHERE AdminUsername = @Username AND AdminPassword = @Password";
                
                using (SqlCommand AdminLogincmd = new SqlCommand(queryText, con))
                {
                    //con.Open();
                    AdminLogincmd.Parameters.AddWithValue("@Username", LoginAdminUsername.Text);
                    AdminLogincmd.Parameters.AddWithValue("@Password", LoginAdminPassword.Text);
                    int result = (int)AdminLogincmd.ExecuteScalar();
                    if (result > 0)
                    {
                        Response.Redirect("AdminManagement.aspx");
                    }
                }
            }
        }
    }
}