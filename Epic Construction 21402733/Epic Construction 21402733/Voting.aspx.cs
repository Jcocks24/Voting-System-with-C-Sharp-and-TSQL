using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Epic_Construction_21402733
{
    public partial class Voting : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        DateTime myDateTime = DateTime.Now;
        private DateTime DateRangeStart;
        private DateTime DateRangeEnd;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand DateRangecmd = new SqlCommand("Select * From DateRangeTable Where DateRangeId=1", con);
            con.Open();
            SqlDataReader DateRangereader = DateRangecmd.ExecuteReader();

            while (DateRangereader.Read())
            {
                DateRangeStart = Convert.ToDateTime(DateRangereader["DateRangeStart"].ToString());
                DateRangeEnd = Convert.ToDateTime(DateRangereader["DateRangeEnd"].ToString());
            }
            DateRangereader.Close();

            LabelStaffName.Text = "Welcome " + Session["StaffLogin"].ToString();
            LabelDate.Text = "The Date Today is: " + myDateTime.ToString();
            LabelDateRange.Text = "Voting takes place between " + DateRangeStart + " and " + DateRangeEnd;
        }

        protected void ButtonReturnAdmin_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void ButtonConfirmCandidate_Click(object sender, EventArgs e)
        {
            SqlCommand DateRangecmd = new SqlCommand("Select * From DateRangeTable Where DateRangeId=1", con);

            if (myDateTime >= DateRangeStart && myDateTime <= DateRangeEnd)
            {
                try
                {
                    SqlCommand UpdateStaffCmd = new SqlCommand("Update StaffTable Set Voted = @Voted, VoteTime = @VoteTime Where StaffFName='" + Session["StaffLogin"] + "'", con);
                    UpdateStaffCmd.Parameters.AddWithValue("@Voted", "1");
                    UpdateStaffCmd.Parameters.AddWithValue("@VoteTime", myDateTime);
                    UpdateStaffCmd.ExecuteNonQuery();
                }
                catch (Exception er)
                {
                    Response.Write("<script language='javascript'> alert('Staff has not voted');</script>");
                }
                try
                {
                    SqlCommand UpdateCandidateCmd = new SqlCommand("Update CandidateTable Set CandidateCount = CandidateCount + 1 Where CandidateCode='" + DropDownListCandidateCode.SelectedValue + "'", con);
                    UpdateCandidateCmd.ExecuteNonQuery();    

                }
                catch (Exception er)
                {
                    Response.Write("<script language='javascript'> alert('Candidate count not updated');</script>");
                }
                finally
                {
                    Response.Write("<script language='javascript'> alert('Thank you for voting.');</script>");
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                LabelDate.Text = "Voting date is outside the date range and votes cannot be accepted.";
            }
            
        }
    }
}


