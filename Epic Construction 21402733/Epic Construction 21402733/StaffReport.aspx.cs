using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Epic_Construction_21402733
{
    public partial class StaffReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        private string VoteTime;
        private string StaffFName;
        private string StaffLName;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand StaffVotedRecordscmd = new SqlCommand("Select * From StaffTable Where Voted=1", con);
            con.Open();
            SqlDataReader StaffVotedRecordsreader = StaffVotedRecordscmd.ExecuteReader();

            while (StaffVotedRecordsreader.Read())
            {
                StaffFName = StaffVotedRecordsreader["StaffFName"].ToString();
                StaffLName = StaffVotedRecordsreader["StaffLName"].ToString();
                VoteTime = StaffVotedRecordsreader["VoteTime"].ToString();

                StringBuilder Html = new StringBuilder();
                Html.Append("<table>");

                Html.Append("<tr>");
                Html.Append("<td>");
                Html.Append(StaffFName + " " + StaffLName);
                Html.Append("</td>");

                Html.Append("<td>");
                Html.Append("&nbsp;&nbsp;&nbsp;" + VoteTime);
                Html.Append("</td>");
                Html.Append("</tr>");

                Html.Append("</table>");
                PlaceHolderStaffVoted.Controls.Add(new Literal { Text = Html.ToString() });
            }
            StaffVotedRecordsreader.Close();
            con.Close();

            SqlCommand StaffRecordscmd = new SqlCommand("Select * From StaffTable Where Voted=0", con);
            con.Open();
            SqlDataReader StaffRecordsreader = StaffRecordscmd.ExecuteReader();

            while (StaffRecordsreader.Read())
            {
                StaffFName = StaffRecordsreader["StaffFName"].ToString();
                StaffLName = StaffRecordsreader["StaffLName"].ToString();

                StringBuilder Html = new StringBuilder();
                Html.Append("<table>");

                Html.Append("<tr>");
                Html.Append("<td>");
                Html.Append(StaffFName + " " + StaffLName);
                Html.Append("</td>");
                Html.Append("</tr>");

                Html.Append("</table>");
                PlaceHolderStaff.Controls.Add(new Literal { Text = Html.ToString() });
            }
            StaffRecordsreader.Close();
            con.Close();
        }

        protected void ButtonReturnAdminManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagement.aspx");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}