using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

using System.Net;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;


namespace Project
{
    public partial class excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        String MyConString = "SERVER=localhost;" +
                "DATABASE=mysql_testing;" +
                "UID=root;" +
                "PASSWORD=tammy;SslMode=none";
        
        protected void importfile()
        {
            String MyConString = "SERVER=localhost;" + "DATABASE=mysql_testing;" + "UID=root;" + "PASSWORD=tammy;SslMode=none";
            if (this.uploadfile.HasFile)
            {
                string fn = this.uploadfile.FileName;
                string[] segments = fn.Split('.');
                string fileExt = segments[segments.Length - 1];
                if (fileExt != "xlsx")
                {
                    showMessage("輸入錯誤", "請上傳正確檔案xlsx");
                    return;
                }
                string newfileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fn;

                string filepath = Server.MapPath(ConfigurationSettings.AppSettings["UPLOAD_FOLDER"]) + newfileName;
                this.uploadfile.SaveAs(filepath);
                ExcelPackage xlWorkbook = new ExcelPackage(new FileInfo(filepath));
                ExcelWorksheet xlRange = xlWorkbook.Workbook.Worksheets[1];
                int rowCount = xlRange.Dimension.End.Row;


                ExcelWorksheet xlRange2 = xlWorkbook.Workbook.Worksheets[2];
                int rowCount2 = xlRange2.Dimension.End.Row;

                string sql = "";
                string linkid = "";
                MySqlConnection conn = null;
                MySqlDataAdapter msda = null;
                DataSet ds = null;
                List<string> FailList = new List<string>();
                conn = new MySqlConnection(MyConString);
                DateTime dTime = DateTime.Now;
                string now_time = dTime.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlCommand cmd = null;
                conn.Open();

               
                conn.Close();
                if (FailList.Count > 0)
                {
                    showMessage("輸入錯誤", "有重覆月結號碼");
                    //listView.DataSource = FailList;
                    // listView.DataBind();
                    File.Delete(filepath);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "tab", "$('.nav-tabs a[href=\"#massimport\"]').tab('show')", true);
                }
                else
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            conn.Open();


                            //sheet1
                            for (int i = 2; i <= rowCount; i++)
                            {
                                string dates = xlRange.Cells[i, 1].Value.ToString();
                                


                                sql = "INSERT INTO mysql_testing.dates set"
                                    + " dates = ?dates;"
                                    
                                    + " select last_insert_id();"
                                                                   /*
                                                                   + " ,in_time = ?in_time"
                                                                   + " ,mod_by = ?mod_by"
                                                                   + " ,mod_time = ?mod_time"
                                                                   + " ,disabled = ?disable"
                                                                   + " ,cust_no = ?cust_no"
                                                                   + " ,net_code = ?net_code"
                                                                   + " ,name = ?name"
                                                                   + " ,addr = ?addr"
                                                                   + " ,contact = ?contact"
                                                                   + " ,tel = ?tel"
                                                                   + " ,fax = ?fax"
                                                                   + " ,email = ?email"
                                                                   + " ,credit_day = ?credit_day"
                                                                   + " ,wh_type = ?wh_type"
                                                                    * */
                                                                   ;

                                //cmd = new MySqlCommand(sql, conn);
                                //cmd.Parameters.AddWithValue("in_by", type);


                                // cmd.ExecuteNonQuery();

                                ds = new DataSet();
                                msda = new MySqlDataAdapter(sql, conn);
                                msda.SelectCommand.Parameters.AddWithValue("dates", dates);
                                

                                msda.Fill(ds, "id");
                                linkid = ds.Tables["id"].Rows[0][0].ToString();
                            }
                            //sheet2


                            

                            showMessage("提示", "儲存成功");
                            scope.Complete();
                            //SaveFileName.Value = null;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            conn.Close();

                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "tab", "$('.nav-tabs a[href=\"#massimport\"]').tab('show')", true);

                }
            }
            else
            {
                showMessage("輸入錯誤", "請選擇檔案");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "tab", "$('.nav-tabs a[href=\"#massimport\"]').tab('show')", true);

            }
        }

        public void showMessage(string title, string content)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + content + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            importfile();
        }
    }
}