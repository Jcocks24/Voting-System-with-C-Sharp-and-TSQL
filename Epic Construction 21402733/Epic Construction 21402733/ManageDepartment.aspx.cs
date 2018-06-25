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
    public partial class ManageDepartment : System.Web.UI.Page
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
            PanelDepartmentManage.Enabled = Panel;
            ButtonAddStaff.Enabled = btnAdd;
            ButtonInsertStaff.Enabled = btnInsert;
            ButtonEditStaff.Enabled = btnEdit;
            ButtonUpdateStaff.Enabled = btnUpdate;
        }
        private void fillList()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DepartmentTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListSelectDepartment.Items.Clear();

            try
            {

                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = MyDataReader["DepartmentId"] + ", " + MyDataReader["DepartmentName"];
                    newitem.Value = MyDataReader["DepartmentId"].ToString();
                    DropDownListSelectDepartment.Items.Add(newitem);
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
            TextBoxDepartmentId.Text = "";
            TextBoxDepartmentName.Text = "";
        }


        protected void DropDownListSelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActive(false, true, false, true, false);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DepartmentTable where DepartmentId='" + DropDownListSelectDepartment.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxDepartmentId.Text = MyDataReader["DepartmentId"].ToString();
                TextBoxDepartmentName.Text = MyDataReader["DepartmentName"].ToString();

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
            buttonActive(true, false, true, false, false);
            TextBoxDepartmentId.Text = "";
            TextBoxDepartmentName.Text = "";
        }

        protected void ButtonInsertStaff_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand InsertCmd = new SqlCommand("Insert into DepartmentTable (DepartmentName) values (@DepartmentName)", sqlConn);

            InsertCmd.Parameters.AddWithValue("@DepartmentName", TextBoxDepartmentName.Text);

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
            SqlCommand cmd = new SqlCommand("select * from DepartmentTable where DepartmentId='" + DropDownListSelectDepartment.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxDepartmentId.Text = MyDataReader["DepartmentId"].ToString();
                TextBoxDepartmentName.Text = MyDataReader["DepartmentName"].ToString();

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
            SqlCommand UpdateCmd = new SqlCommand("Update DepartmentTable Set DepartmentName = @DepartmentName Where DepartmentId='" + DropDownListSelectDepartment.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@DepartmentName", TextBoxDepartmentName.Text);

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

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}