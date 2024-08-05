using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Account : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\School.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Open();


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //To check class id present in class registration or not
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select cls_id from class_registration";
        cmd.ExecuteNonQuery();
        SqlDataReader da1 = cmd.ExecuteReader();
        int c = 0;
        while (da1.Read())
        {
            if (T3.Text == da1.GetValue(0).ToString())
            {
                c = 1; //class  id found in class registration
                break;

            }

        }
        conn.Close();
        conn.Open();
        //To check student id present in student admission or not
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select student_id from student_admission";
        cmd.ExecuteNonQuery();
        da1 = cmd.ExecuteReader();
        int s = 0;
        while (da1.Read())
        {
            if (T2.Text == da1.GetValue(0).ToString())
            {
                s = 1; //Student id found in student admission
                break;

            }

        }
        conn.Close();
        conn.Open();
        //To check account date is present in the account table or not
    
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select a_date from account";
        cmd.ExecuteNonQuery();
        da1 = cmd.ExecuteReader();
        int a = 0; 
        while (da1.Read())
        {
           if (T1.Text == da1.GetValue(0).ToString())
           {
                    a = 1;
                    break;
                    
            }

        }
        conn.Close();
        conn.Open();

        
        if (a == 0 && s==1 && c==1)
        {
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into Account values('" + T1.Text + "','" + T2.Text + "','" + T3.Text + "','" + T4.Text + "','" + T5.Text + "','" + T6.Text + "','" + T7.Text + "','" + T8.Text + "','" + T9.Text + "')";
            cmd1.ExecuteNonQuery();
            Response.Write("<script> alert('Record Saved')</script>");
            SqlDataSource1.SelectCommand = "SELECT * FROM Account";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        else if(a==1)
            Response.Write("<script>alert('Account Date already exist')</script>");
        else if(s==0)
            Response.Write("<script>alert('Student id not exist ')</script>");
        else if (c== 0)
            Response.Write("<script>alert('Class id not exist ')</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        T1.Text = "";
        T2.Text = "";
        T3.Text = "";
        T4.Text = "";
        T5.Text = "";
        T6.Text = "";
        T7.Text = "";
        T8.Text = "";
        T9.Text = "";
      
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //To delete the record
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from Account  where a_date='" + T1.Text + "'";
        cmd.ExecuteNonQuery();
        Response.Write("<script> alert('Record Deleted')</script>");
        SqlDataSource1.SelectCommand = "SELECT * FROM Account";
        GridView1.DataSourceID = "SqlDataSource1";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //To update the record
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update Account set student_id='" + T2.Text + "',cls_id='" + T3.Text + "',cls_name='" + T4.Text + "',exam_type='" + T5.Text + "',fee_type='" + T6.Text + "',category='" + T7.Text + "' ,amt='" + T8.Text + "',slip_no='" + T9.Text + "'where a_date='" + T1.Text + "'";
        cmd.ExecuteNonQuery();
        Response.Write("<script> alert('Record Updated')</script>");
        SqlDataSource1.SelectCommand = "SELECT * FROM Account";
        GridView1.DataSourceID = "SqlDataSource1";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        //Particular Search
        SqlCommand cmd1 = conn.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "select * from Account where a_date='" + T1.Text + "'";
        cmd1.ExecuteNonQuery();
        SqlDataReader da1 = cmd1.ExecuteReader();
        while (da1.Read())
        {
            T2.Text = da1.GetValue(1).ToString();
            T3.Text = da1.GetValue(2).ToString();
            T4.Text = da1.GetValue(3).ToString();
            T5.Text = da1.GetValue(4).ToString();
            T6.Text = da1.GetValue(5).ToString();
            T7.Text = da1.GetValue(6).ToString();
            T8.Text = da1.GetValue(7).ToString();
            T9.Text = da1.GetValue(8).ToString();


        }
        SqlDataSource1.SelectCommand = "select * from Account where a_date='" + T1.Text + "'";
        GridView1.DataSourceID = "SqlDataSource1";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT * FROM Account";
        GridView1.DataSourceID = "SqlDataSource1";
    }
}
