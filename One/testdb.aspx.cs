using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class testdb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.

                DataTable dt = this.GetData();
                if (dt != null)
                { 
                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1' class= 'table'>");

                //Building the Header row.
                /*
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");
                    */
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            }



            }
        }

        private DataTable GetData()
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string constr = "Server=localhost;Database=life;Uid=root;Pwd='tammy';SslMode=none";

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM techstory where id = 2"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)

                            {

                                return dt;
                            }


                            else {
                                Label1.Text = "nodata";
                                return null ;

                            }
                        }
                    }
                }
            }
        }
    }
}