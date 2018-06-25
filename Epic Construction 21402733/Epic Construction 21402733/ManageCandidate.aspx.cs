using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace Epic_Construction_21402733
{
    public partial class ManageCandidate : System.Web.UI.Page
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

        private void fillList()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from CandidateTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListSelectCandidate.Items.Clear();

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = MyDataReader["CandidateId"] + ", " + MyDataReader["CandidateFName"] + ", " + MyDataReader["CandidateLName"] + ", " + MyDataReader["CandidateDepartment"] + ", " + MyDataReader["CandidateCode"];
                    newitem.Value = MyDataReader["CandidateId"].ToString();
                    DropDownListSelectCandidate.Items.Add(newitem);
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

        protected void buttonActive(bool Panel, bool btnAdd, bool btnInsert, bool btnEdit, bool btnUpdate, bool btnDelete)
        {
            PanelCandidateManage.Enabled = Panel;
            ButtonAddCandidate.Enabled = btnAdd;
            ButtonInsertCandidate.Enabled = btnInsert;
            ButtonEditCandidate.Enabled = btnEdit;
            ButtonUpdateCandidate.Enabled = btnUpdate;
            ButtonDeleteCandidate.Enabled = btnDelete;
        }

        protected void ClearPanel()
        {
            TextBoxCandidateId.Text = "";
            TextBoxCandidateFirstName.Text = "";
            TextBoxCandidateLastName.Text = "";
            TextBoxCandidateCode.Text = "";
        }

        protected void DropDownListSelectCandidate_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActive(false, true, false, true, false, true);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from CandidateTable where CandidateId='" + DropDownListSelectCandidate.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxCandidateId.Text = MyDataReader["CandidateId"].ToString();
                TextBoxCandidateFirstName.Text = MyDataReader["CandidateFName"].ToString();
                TextBoxCandidateLastName.Text = MyDataReader["CandidateLName"].ToString();
                DropDownListDepartment.Text = MyDataReader["CandidateDepartment"].ToString();
                TextBoxCandidateCode.Text = MyDataReader["CandidateCode"].ToString();

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

        protected void ButtonAddCandidate_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, true, false, false, false);
            TextBoxCandidateId.Text = "";
            TextBoxCandidateFirstName.Text = "";
            TextBoxCandidateLastName.Text = "";
            fillListDepartment();
            TextBoxCandidateCode.Text = "";
        }

        protected void ButtonInsertCandidate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand command = new SqlCommand("SELECT CandidateCode FROM CandidateTable", sqlConn);
            sqlConn.Open();
            string value = command.ExecuteScalar() as string;

            if (TextBoxCandidateCode.Text.Equals(value))
            {
                LabelCodeExists.Text = "Candidate code already exists, please choose another.";
            }
            else
            {
                SqlCommand InsertCmd = new SqlCommand("Insert into CandidateTable (CandidateFName, CandidateLName, CandidateDepartment, CandidateCode, CandidateCount) values (@CandidateFName, @CandidateLName, @CandidateDepartment, @CandidateCode, @CandidateCount)", sqlConn);

                InsertCmd.Parameters.AddWithValue("@CandidateFName", TextBoxCandidateFirstName.Text);
                InsertCmd.Parameters.AddWithValue("@CandidateLName", TextBoxCandidateLastName.Text);
                InsertCmd.Parameters.AddWithValue("@CandidateDepartment", DropDownListDepartment.Text);
                InsertCmd.Parameters.AddWithValue("@CandidateCode", TextBoxCandidateCode.Text);
                InsertCmd.Parameters.AddWithValue("@CandidateCount", "0");

                InsertCmd.ExecuteNonQuery();
                Response.Write("<script language='javascript'> alert('Record has been added successfully');</script>");

                sqlConn.Close();
                buttonActive(false, true, false, false, false, false);
                fillList();
                ClearPanel();
            }


        }

        protected void ButtonEditCandidate_Click(object sender, EventArgs e)
        {
            buttonActive(true, false, false, false, true, false);

            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from CandidateTable where CandidateId='" + DropDownListSelectCandidate.SelectedValue + "'", sqlConn);
            SqlDataReader MyDataReader;

            try
            {
                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                MyDataReader.Read();

                TextBoxCandidateId.Text = MyDataReader["CandidateId"].ToString();
                TextBoxCandidateFirstName.Text = MyDataReader["CandidateFName"].ToString();
                TextBoxCandidateLastName.Text = MyDataReader["CandidateLName"].ToString();
                fillListDepartment();
                TextBoxCandidateCode.Text = MyDataReader["CandidateCode"].ToString();



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

        protected void ButtonUpdateCandidate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand UpdateCmd = new SqlCommand("Update CandidateTable Set CandidateFName = @CandidateFName, CandidateLName = @CandidateLName, CandidateDepartment = @CandidateDepartment, CandidateCode = @CandidateCode Where CandidateId='" + DropDownListSelectCandidate.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@CandidateFName", TextBoxCandidateFirstName.Text);
            UpdateCmd.Parameters.AddWithValue("@CandidateLName", TextBoxCandidateLastName.Text);
            UpdateCmd.Parameters.AddWithValue("@CandidateDepartment", DropDownListDepartment.Text);
            UpdateCmd.Parameters.AddWithValue("@CandidateCode", TextBoxCandidateCode.Text);

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

        protected void ButtonDeleteCandidate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand UpdateCmd = new SqlCommand("Delete From CandidateTable Where CandidateId='" + DropDownListSelectCandidate.SelectedValue + "'", sqlConn);

            UpdateCmd.Parameters.AddWithValue("@CandidateFName", TextBoxCandidateFirstName.Text);
            UpdateCmd.Parameters.AddWithValue("@CandidateLName", TextBoxCandidateLastName.Text);
            UpdateCmd.Parameters.AddWithValue("@CandidateCode", TextBoxCandidateCode.Text);

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

        private void fillListDepartment()
        {
            SqlConnection sqlConn = new SqlConnection(myConnStr);
            SqlCommand cmd = new SqlCommand("select * from DepartmentTable", sqlConn);
            SqlDataReader MyDataReader;
            DropDownListDepartment.Items.Clear();

            try
            {

                sqlConn.Open();
                MyDataReader = cmd.ExecuteReader();
                while (MyDataReader.Read())
                {
                    ListItem newitem = new ListItem();
                    newitem.Text = MyDataReader["DepartmentId"] + ", " + MyDataReader["DepartmentName"];
                    newitem.Value = MyDataReader["DepartmentName"].ToString();
                    DropDownListDepartment.Items.Add(newitem);
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

    }
}