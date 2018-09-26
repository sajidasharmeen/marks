using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageStore_Example
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String conn = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString.ToString();
        string imgname;
        int imgsize;
        string imgpath;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            imgname = FileUpload1.FileName.ToString();
            imgpath = "images/" + imgname;
            FileUpload1.SaveAs(Server.MapPath(imgpath));
            imgsize = FileUpload1.PostedFile.ContentLength;

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                if (FileUpload1.PostedFile.ContentLength > 51200) //50 mb
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('file is too big')", true);
                }
                else
                {
                    try
                        {
                        SqlConnection cn=new SqlConnection(conn);
                        cn.Open();
                      
                       string sql_query="insert into img_table (img_name,img_size,img_path) values ('"+imgname+"','"+imgsize+"','"+imgpath+"')";
                        SqlCommand cmd=new SqlCommand(sql_query,cn);
                        cmd.ExecuteNonQuery();
                        Response.Write("image saved in database");
                        cn.Close();
                          }
                      catch (Exception ex)
                      {
                         Response.Write(ex.Message);
                     }
        }

                }
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
         //show image
            try
            {
                SqlConnection cn = new SqlConnection(conn);
                cn.Open();

                string sql_query = "select * from img_table where img_name='"+TextBox1.Text+"' ";
                SqlCommand cmd = new SqlCommand(sql_query, cn);
                cmd.ExecuteNonQuery();
              Image1.ImageUrl = "images/"+ TextBox1.Text;
                cn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


        }
        }

       
            

       
    }
