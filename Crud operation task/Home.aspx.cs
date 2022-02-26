using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    dbManager db= new dbManager("Data Source=DESKTOP-3DA4QL0;Initial Catalog=task;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            DataSet Companyds = new DataSet();
            Companyds = db.getData("select * from dbo.Company");

            if (Companyds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = Companyds.Tables[0];
                DropDownList1.DataTextField = "Company_Name";
                DropDownList1.DataValueField = "Company_id";

                DropDownList1.DataBind();
            }
            else
            {

            }
        }

    }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        int result = db.execute_Query("insert into Emp(Emp_id,Emp_Name,Emp_DOJ,Emp_Sal,Company_id) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')");

        if (result == 1)
        {
            Label1.Text = "Record inserted Successfully.";
            
        }
        else
        {
            Label1.Text = "Something went wrong try again.";
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        int result = db.execute_Query("Update Emp set Emp_id='" + TextBox1.Text + "',Emp_Name='"+TextBox2.Text+"'");

        if (result >= 1)
        {
            Label1.Text = "Record Updated Successfully.";
           
        }
        else
        {
            Label1.Text = "Something went wrong try again.";
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int result = db.execute_Query("delete from Emp where Emp_id ='" + TextBox1.Text + "'");

        if (result >= 1)
        {
            Label1.Text = "Record delete Successfully.";
            
        }
        else
        {
            Label1.Text = "Something went wrong try again.";
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        
    }
}