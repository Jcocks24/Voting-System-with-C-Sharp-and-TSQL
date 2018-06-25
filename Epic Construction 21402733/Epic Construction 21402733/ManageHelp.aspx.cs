using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Epic_Construction_21402733
{
    public partial class ManageHelp : System.Web.UI.Page
    {
        private string myConnStr =
        WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                fillList();
            }

            buttonActive(false, true, false, false, false);
        }

        protected void buttonActive(bool Panel, bool btnAdd, bool btnInsert, bool btnEdit, bool btnUpdate)
        {
            PanelHelpManage.Enabled = Panel;
            ButtonAddStaff.Enabled = btnAdd;
            ButtonInsertStaff.Enabled = btnInsert;
            ButtonEditStaff.Enabled = btnEdit;
            ButtonUpdateStaff.Enabled = btnUpdate;
        }

        private void fillList()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from HelpTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListSelectHelp.Items.Clear();

            try
            {

                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = MyDataReader["HelpId"] + ", " + MyDataReader["HelpQuestion"] + ", " + MyDataReader["HelpAnswer"];
                    newitem.Value = MyDataReader["HelpId"].ToString();
                    DropDownListSelectHelp.Items.Add(newitem);
                }


            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Database connection failed');</script>");
            }
            finally
            {
                sqlConn.Close();
            }

        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void ClearPanel()
        {
            TextBoxHelpId.Text = "";
            TextBoxHelpQuestion.Text = "";
            TextBoxHelpAnswer.Text = "";
        }

        protected void ButtonAddStaff_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, true, false, false);
            TextBoxHelpId.Text = "";
            TextBoxHelpQuestion.Text = "";
            TextBoxHelpAnswer.Text = "";
        }

        protected void ButtonInsertStaff_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand InsertCmd = new SqlCommand("Insert into HelpTable (HelpQuestion, HelpAnswer) values (@HelpQuestion, @HelpAnswer)", sqlConn);

            InsertCmd.Parameters.AddWithValue("@HelpQuestion", TextBoxHelpQuestion.Text);
            InsertCmd.Parameters.AddWithValue("@HelpAnswer", TextBoxHelpAnswer.Text);

            try
            {
                sqlConn.Open();
                InsertCmd.ExecuteNonQuery();
                Response.Write("<script language='javascript'> alert('Record has been added successfully');</script>");

            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Error! Database connection falied');</script>");
            }
            finally
            {
                sqlConn.Close();
                buttonActive(false, true, false, false, false);
                fillList();
                ClearPanel();

            }
        }

        protected void ButtonEditStaff_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, false, false, true);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from HelpTable where HelpId='" + DropDownListSelectHelp.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxHelpId.Text = MyDataReader["HelpId"].ToString();
                TextBoxHelpQuestion.Text = MyDataReader["HelpQuestion"].ToString();
                TextBoxHelpAnswer.Text = MyDataReader["HelpAnswer"].ToString();

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

        protected void ButtonUpdateStaff_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand UpdateCmd = new SqlCommand("Update HelpTable Set HelpQuestion = @HelpQuestion, HelpAnswer = @HelpAnswer Where HelpId='" + DropDownListSelectHelp.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@HelpQuestion", TextBoxHelpQuestion.Text);
            UpdateCmd.Parameters.AddWithValue("@HelpAnswer", TextBoxHelpAnswer.Text);

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
                sqlConn.Close();
                buttonActive(false, true, false, false, false);
                fillList();
                ClearPanel();

            }
        }

        protected void DropDownListSelectHelp_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActive(false, true, false, true, false);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from HelpTable where HelpId='" + DropDownListSelectHelp.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxHelpId.Text = MyDataReader["HelpId"].ToString();
                TextBoxHelpQuestion.Text = MyDataReader["HelpQuestion"].ToString();
                TextBoxHelpAnswer.Text = MyDataReader["HelpAnswer"].ToString();

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
    }
}