using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Epic_Construction_21402733
{
    public partial class DateRange : System.Web.UI.Page
    {
        private string myConnStr =
        WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            fillList();
            buttonActive(false, true, false);
        }

        protected void buttonActive(bool Panel, bool btnEdit, bool btnUpdate)
        {
            PanelDateRangeManage.Enabled = Panel;
            ButtonEdit.Enabled = btnEdit;
            ButtonUpdate.Enabled = btnUpdate;
        }

        private void fillList()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DateRangeTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListDateRange.Items.Clear();

            try
            {

                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = "Start Date: " + MyDataReader["DateRangeStart"] + ". End Date:" + MyDataReader["DateRangeEnd"];
                    newitem.Value = MyDataReader["DateRangeId"].ToString();
                    DropDownListDateRange.Items.Add(newitem);
                }

            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Database connection failed');</script>");
            }
            finally
            {
                //sqlConn.Close();
            }

        }

        protected void ButtonReturnAdminManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagement.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, true);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DateRangeTable", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxDateRangeId.Text = MyDataReader["DateRangeId"].ToString();
                TextBoxDateRangeStart.Text = MyDataReader["DateRangeStart"].ToString();
                TextBoxDateRangeEnd.Text = MyDataReader["DateRangeEnd"].ToString();
                

                //Response.Write("<script language='javascript'> alert('Database connection openned');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Database connection failed');</script>");
                //Response.Write("<script language='javascript'> alert('Customer not found!');</script>");
            }
            finally
            {
                //sqlConn.Close();
                //Response.Write("<script language='javascript'> alert('Database connection closed');</script>");
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand UpdateCmd = new SqlCommand("Update DateRangeTable Set DateRangeStart = @DateRangeStart, DateRangeEnd = DATEADD(DAY, 6, @DateRangeStart)", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@DateRangeStart", Convert.ToDateTime(TextBoxDateRangeStart.Text));

            try
            {
                sqlConn.Open();
                UpdateCmd.ExecuteNonQuery();
                Response.Write("<script language='javascript'> alert('Record has been updated successfully');</script>");

            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Error! Database connection falied');</script>");
            }
            finally
            {
                //sqlConn.Close();
                buttonActive(false, false, false);
                //fillList();
                Response.Redirect("DateRange.aspx");
            }
        }

        protected void DropDownListDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActive(false, true, false);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DateRangeTable", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                //TextBoxDateRangeId.Text = MyDataReader["DateRangeId"].ToString();
                TextBoxDateRangeStart.Text = MyDataReader["DateRangeStart"].ToString();
                TextBoxDateRangeEnd.Text = MyDataReader["DateRangeEnd"].ToString();

                //Response.Write("<script language='javascript'> alert('Database connection openned');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Database connection failed');</script>");
                //Response.Write("<script language='javascript'> alert('Customer not found!');</script>");
            }
            finally
            {
                sqlConn.Close();
                //  Response.Write("<script language='javascript'> alert('Database connection closed');</script>");
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}