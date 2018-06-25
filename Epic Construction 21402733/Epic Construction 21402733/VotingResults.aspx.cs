using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace Epic_Construction_21402733
{
    public partial class VotingResults : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        private int TotalStaff;
        private double TotalVoted;
        private double CandidateCount;
        private double CandidateCountPercentage;
        private string CandidateFName;
        private string CandidateLName;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand TotalStaffcmd = new SqlCommand("Select * From StaffTable", con);
            con.Open();
            SqlDataReader TotalStaffreader = TotalStaffcmd.ExecuteReader();

            while (TotalStaffreader.Read())
            {
                TotalStaff = Convert.ToInt32(TotalStaffreader[0].ToString());
            }
            TotalStaffreader.Close();

            LabelVotingList.Text = "Staff on Voting List: " + TotalStaff;
            con.Close();

            SqlCommand TotalVotedcmd = new SqlCommand("Select COUNT(*) From StaffTable Where Voted=1", con);
            con.Open();
            SqlDataReader TotalVotedreader = TotalVotedcmd.ExecuteReader();

            while (TotalVotedreader.Read())
            {
                TotalVoted = Convert.ToInt32(TotalVotedreader[0].ToString());
            }
            TotalVotedreader.Close();

            LabelNumbersVoted.Text = "Staff Voted: " + TotalVoted;
            con.Close();

            SqlCommand CandidateStatisticscmd = new SqlCommand("Select * From CandidateTable", con);
            con.Open();
            SqlDataReader CandidateStatisticsreader = CandidateStatisticscmd.ExecuteReader();

            while (CandidateStatisticsreader.Read())
            {
                CandidateFName = CandidateStatisticsreader["CandidateFName"].ToString();
                CandidateLName = CandidateStatisticsreader["CandidateLName"].ToString();
                CandidateCount = Convert.ToInt32(CandidateStatisticsreader["CandidateCount"].ToString());
                CandidateCountPercentage = (CandidateCount / TotalVoted) * 100;

                StringBuilder Html = new StringBuilder();
                Html.Append("<table>");

                Html.Append("<tr>");
                Html.Append("<td>");
                Html.Append(CandidateFName + " " + CandidateLName + "&nbsp;&nbsp;" + CandidateCount + "&nbsp;&nbsp;" + "(" + CandidateCountPercentage + "%" + ")");
                Html.Append("</td>");
                Html.Append("</tr>");

                Html.Append("</table>");

                PlaceHolderCandidateStatistics.Controls.Add(new Literal { Text = Html.ToString() });
            }
            CandidateStatisticsreader.Close();
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