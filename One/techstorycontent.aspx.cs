using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Project
{
    public partial class techstorycontent : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
            {
            //Populating a string from database.
           
            string html = getWhileLoopData();
            //
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            string userid = Convert.ToString(Session["userid"]);
                if (userid == null)
                {

                    Response.Redirect("login00.aspx");
                }
            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                getWhileLoopData();
            }

            public string getWhileLoopData()
            {
            String htmlStr = "";

            string search = Request.QueryString["search"];
               // string htmlStr = "";
                //string tets = TextBoxfrom.Text;

                String MyConString = "SERVER=localhost;" + "DATABASE=life;" + "UID=root;" + "PASSWORD=tammy;SslMode=none";
                MySqlConnection conn = new MySqlConnection(MyConString);



            // string sql = "SELECT * FROM header where accountno ='" + TextBox1.Text + "'"
            // + "and date >='" + TextBoxfrom.Text + "'" + "and date <='" + TextBoxto.Text + "'";
            string sql = "SELECT * FROM techstory where id='1'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

            //htmlStr += "<table class='table'>" +"<tr><th>" + "公司名" + "</th>" + "<th>" + "預覽發票" + "</th>" + "<th>" + "打印發票" + "</th>" + "</tr>";

            if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {

                        int id = reader.GetInt32(0);
                        string Name = reader.GetString(2);
                        string body = reader.GetString(6);
                    htmlStr +=

//"<tr>" +"<td>" + Name + "</td>" +
//"<td><a href='newwindowhtmlformat.aspx?linkno=" + id + " &accountno=" +  " target='_blank'>" + "預覽發票" + "</a>" + "</td>"
// + "<td><a href='htmlformatpdf.aspx?linkno=" + id + " &accountno=" + "'  target='_blank'>" + "打印發票" + "</a>" + "</td>"
//+ "</tr>";


"<form>" +
"<div class='form-group'>Email address<input type = 'email' class='form-control' id='exampleFormControlInput1' value='" + Name + "'>"+"</div>"
+ "<div class='form-group'><label for='exampleFormControlTextarea1'>Example textarea</label>"
+ "<textarea class='form-control' id='exampleFormControlTextarea1' rows='3'>" + body + "</textarea>"
+ "</div>"
+ "</form>";

                }

//htmlStr += "</table>";
                    conn.Close();
                    // TextBox1.Visible = false;
                    //Label1.Visible = false;
                    //Button1.Visible = false;
                    return htmlStr;

                }

                else
                {
                    conn.Close();
                    // Response.Redirect("nowaybillno.aspx");
                    //Label1.Visible = true;
                    //Label1.Text = "No such waybill number in the database. Please check and try again.";
                    return "";
                }

            }
        //end of getting data from database

        }
    }


