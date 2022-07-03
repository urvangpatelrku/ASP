using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cookies_practice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnretrive_Click(object sender, EventArgs e)
        {
            if (Response.Cookies["sname"] == null)
            {
                txtretrive.Text = "Cookies not found";
            }
            else
            {
                txtretrive.Text = Request.Cookies["sname"].Value;
                //Request.Cookies["uname"].Value = txtretrive.Text.ToString(); 
            }
           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Cookies["sname"].Value = txtadd.Text.ToString();
            Response.Cookies["sname"].Expires = DateTime.Now.AddSeconds(10);
            txtadd.Text = "";

        }
    }
}

//Query String 
WebForm2.aspx
            Response.Redirect("WebForm3.aspx?firstname=" + txtname.Text + "&lastname=" + txtlname.Text);

WebForm3.aspx
			 string firstname = Request.QueryString["firstname"];
            string lastname = Request.QueryString["lastname"];
            Label1.Text = "welcome" + firstname + " " + lastname;