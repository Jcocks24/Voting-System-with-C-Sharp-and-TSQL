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
    public partial class ManageStaff : System.Web.UI.Page
    {
        private string myConnStr =
        WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                fillList();
            }

            buttonActive(false, true, false, false, false, false);
        }

        protected void buttonActive(bool Panel, bool btnAdd, bool btnInsert, bool btnEdit, bool btnUpdate, bool btnDelete)
        {
            PanelStaffManage.Enabled = Panel;
            ButtonAddStaff.Enabled = btnAdd;
            ButtonInsertStaff.Enabled = btnInsert;
            ButtonEditStaff.Enabled = btnEdit;
            ButtonUpdateStaff.Enabled = btnUpdate;
            ButtonDeleteStaff.Enabled = btnDelete;
        }

        private void fillList()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from StaffTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListSelectStaff.Items.Clear();

            try
            {

                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = MyDataReader["StaffId"] + ", " + MyDataReader["StaffFName"] + ", " + MyDataReader["StaffLName"] + ", " + MyDataReader["StaffUsername"] + ", " + MyDataReader["StaffPassword"] + ", " + MyDataReader["StaffEmail"];
                    newitem.Value = MyDataReader["StaffId"].ToString();
                    DropDownListSelectStaff.Items.Add(newitem);
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

        protected void ClearPanel()
        {
            TextBoxStaffId.Text = "";
            TextBoxStaffFirstName.Text = "";
            TextBoxStaffLastName.Text = "";
            TextBoxStaffUsername.Text = "";
            TextBoxStaffPassword.Text = "";
            TextBoxStaffEmail.Text = "";
        }

        protected void DropDownListSelectStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActive(false, true, false, true, false, true);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from StaffTable where StaffId='" + DropDownListSelectStaff.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxStaffId.Text = MyDataReader["StaffId"].ToString();
                TextBoxStaffFirstName.Text = MyDataReader["StaffFName"].ToString();
                TextBoxStaffLastName.Text = MyDataReader["StaffLName"].ToString();
                TextBoxStaffUsername.Text = MyDataReader["StaffUsername"].ToString();
                TextBoxStaffPassword.Text = MyDataReader["StaffPassword"].ToString();
                TextBoxStaffEmail.Text = MyDataReader["StaffEmail"].ToString();

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

        protected void ButtonAddStaff_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, true, false, false, false);
            TextBoxStaffId.Text = "";
            TextBoxStaffFirstName.Text = "";
            TextBoxStaffLastName.Text = "";
            TextBoxStaffUsername.Text = "";
            TextBoxStaffPassword.Text = "";
            TextBoxStaffEmail.Text = "";
        }

        protected void ButtonInsertStaff_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);

            SqlCommand command = new SqlCommand("SELECT StaffUsername FROM StaffTable", sqlConn);
            sqlConn.Open();
            string value = command.ExecuteScalar() as string;

            if (TextBoxStaffUsername.Text.Equals(value))
            {
                LabelUsernameExists.Text = "Username already exists, please choose another.";
            }
            else
            {
                SqlCommand InsertCmd = new SqlCommand("Insert into StaffTable (StaffFName, StaffLName, StaffUsername, StaffPassword, StaffEmail, Voted) values (@StaffFName, @StaffLName, @StaffUsername, @StaffPassword, @StaffEmail, @Voted)", sqlConn);
                InsertCmd.Parameters.AddWithValue("@StaffFName", TextBoxStaffFirstName.Text);
                InsertCmd.Parameters.AddWithValue("@StaffLName", TextBoxStaffLastName.Text);
                InsertCmd.Parameters.AddWithValue("@StaffUsername", TextBoxStaffUsername.Text);
                InsertCmd.Parameters.AddWithValue("@StaffPassword", TextBoxStaffPassword.Text);
                InsertCmd.Parameters.AddWithValue("@StaffEmail", TextBoxStaffEmail.Text);
                InsertCmd.Parameters.AddWithValue("@Voted", "0");
                InsertCmd.ExecuteNonQuery();
            }

            try
            {            
                Response.Write("<script language='javascript'> alert('Record has been added successfully');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Error! Database connection falied');</script>");
            }
            finally
            {
                sqlConn.Close();
                buttonActive(false, true, false, false, false, false);
                fillList();
                ClearPanel();
            }
        }

        protected void ButtonEditStaff_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, false, false, true, false);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from StaffTable where StaffId='" + DropDownListSelectStaff.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxStaffId.Text = MyDataReader["StaffId"].ToString();
                TextBoxStaffFirstName.Text = MyDataReader["StaffFName"].ToString();
                TextBoxStaffLastName.Text = MyDataReader["StaffLName"].ToString();
                TextBoxStaffUsername.Text = MyDataReader["StaffUsername"].ToString();
                TextBoxStaffPassword.Text = MyDataReader["StaffPassword"].ToString();
                TextBoxStaffEmail.Text = MyDataReader["StaffEmail"].ToString();

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
            SqlCommand UpdateCmd = new SqlCommand("Update StaffTable Set StaffFName = @StaffFName, StaffLName = @StaffLName, StaffUsername = @StaffUsername, StaffPassword = @StaffPassword, StaffEmail = @StaffEmail Where StaffId='" + DropDownListSelectStaff.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@StaffFName", TextBoxStaffFirstName.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffLName", TextBoxStaffLastName.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffUsername", TextBoxStaffUsername.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffPassword", TextBoxStaffPassword.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffEmail", TextBoxStaffEmail.Text);

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
                buttonActive(false, true, false, false, false, false);
                fillList();
                ClearPanel();

            }
        }

        protected void ButtonDeleteStaff_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand UpdateCmd = new SqlCommand("Delete From StaffTable Where StaffId='" + DropDownListSelectStaff.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@StaffFName", TextBoxStaffFirstName.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffLName", TextBoxStaffLastName.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffUsername", TextBoxStaffUsername.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffPassword", TextBoxStaffPassword.Text);
            UpdateCmd.Parameters.AddWithValue("@StaffEmail", TextBoxStaffEmail.Text);

            try
            {
                sqlConn.Open();
                UpdateCmd.ExecuteNonQuery();
                Response.Write("<script language='javascript'> alert('Record has been deleted successfully');</script>");

            }
            catch (Exception er)
            {
                Response.Write("<script language='javascript'> alert('Error! Database connection falied');</script>");
            }
            finally
            {
                sqlConn.Close();
                buttonActive(false, true, false, false, false, false);
                fillList();
                ClearPanel();

            }
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