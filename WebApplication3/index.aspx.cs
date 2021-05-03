using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class index : System.Web.UI.Page
    {   
        SqlConnection conn = new SqlConnection(DBConnection.connString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadDropDown();
            }
        }




        



        void LoadData()
        {
            try
            {
                string s = "select id as SL, emp_id as ID, emp_name as Name," +
                                "(select d.dept_name from Department d where d.id=e.emp_dept) as Department, emp_gender as Gender, e.emp_dept " +
                            " from EmployeeDetails e ";
                da = new SqlDataAdapter(s, conn);
                dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }


        void LoadDropDown()
        {
            try
            {
                string s = " Select * from Department ";
                da = new SqlDataAdapter(s, conn);
                dt = new DataTable();
                da.Fill(dt);
                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "-- Select --";
                dt.Rows.InsertAt(dr,0);
                DropDownDept.DataSource = dt;
                DropDownDept.DataTextField = "dept_name";
                DropDownDept.DataValueField = "id";
                DropDownDept.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }




        void Clear()
        {
            txtRecordID.Text = lblMessage.Text = 
            txtEmp_id.Text = txtEmp_name.Text = "";
                 DropDownDept.SelectedIndex = 0;
            rdoGender.SelectedValue = "";
            btnSave.Text = "Save";
        }




    

        

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (!txtEmp_id.Text.Trim().All(char.IsDigit)) { lblMessage.Text = "insert Employee ID is number"; return; }
            else{ lblMessage.Text = ""; }
            string s = "";
            try
            {
                if (btnSave.Text=="Save")
                {
                    s = @" insert into EmployeeDetails values('" + int.Parse(txtEmp_id.Text.Trim()) + "', " +
                    " '" + txtEmp_name.Text.Trim() + "', " + DropDownDept.SelectedValue + ", '" + rdoGender.SelectedValue + "' )";
                }
                else
                {
                    s = @" Update EmployeeDetails SET emp_id = '" + int.Parse(txtEmp_id.Text.Trim()) + "', " +
                    " emp_name = '" + txtEmp_name.Text.Trim() + "', emp_dept = " + DropDownDept.SelectedValue + ", " +
                    " emp_gender = '" + rdoGender.SelectedValue + "' where id = "+txtRecordID.Text.Trim()+" ";
                }
                cmd = new SqlCommand(s, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Update";
            int RowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            txtRecordID.Text  = GridView1.Rows[RowIndex].Cells[1].Text;
            txtEmp_id.Text    = GridView1.Rows[RowIndex].Cells[2].Text;
            txtEmp_name.Text  = GridView1.Rows[RowIndex].Cells[3].Text;
            rdoGender.SelectedValue = GridView1.Rows[RowIndex].Cells[5].Text.Trim();
            DropDownDept.SelectedValue = GridView1.Rows[RowIndex].Cells[6].Text;        
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRecordID.Text.Trim()=="") { lblMessage.Text = "Please Select One Record"; return; }
                string s = " delete from EmployeeDetails where id = "+txtRecordID.Text.Trim();
                cmd = new SqlCommand(s, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }
}