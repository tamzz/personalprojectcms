using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Login() {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sql = "SELECT * FROM user Where user_id =" + Userid.Text;
            MySqlCommand cmd = new MySqlCommand(sql);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)

            {
                //output the table to the page
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                // Response.Redirect("Front.aspx");
                Label1.Text = "ok";

            }
            else
            {

            }
 
}


        private void db() {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(constr);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM user Where user_id ='" + Userid.Text + "'" + "And password='" + Password.Text + "'";

            MySqlDataReader reader = command.ExecuteReader();

            //if return data != null

            if (reader.HasRows)
            {
                while (reader.Read())
                {   //get the 1st column of data from db
                    reader.GetString(0);
                    //get the column of data using the name of the column
                    Label1.Text = reader["user_id"].ToString();

                    Session["username"] = reader["username"].ToString();

                    Response.Redirect("home.aspx");
                }

                //reader["column_name"].ToString()
            }


            else
            {
                Label1.Text = "incorrect credential";
            }


                reader.Close();


            } 

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Login();
            db();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedItem.Text;

            if (DropDownList1.SelectedItem.Text == "January")
            {
                rblMeasurementSystem.Enabled = false;
                mm.DataValueField = "Jan";
            }

            else {
                rblMeasurementSystem.Enabled = true;
            }

            var value = DropDownList1.SelectedValue;
            if (value == "1")
            {
                mm.DataValueField = "Jan";
               
   }
            else if (value == "2")
            {
                mm.DataValueField = "Feb";
            }


        }

       

        protected void rblMeasurementSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = rblMeasurementSystem.SelectedItem.Text;
        }
    }
}