// Validation
ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

<asp:RequiredFieldValidator ID="reqname" runat="server" ErrorMessage="Enter Name" ForeColor="red" ControlToValidate="txtname"></asp:RequiredFieldValidator>
Email:  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Incorrect Formet"></asp:RegularExpressionValidator>
RePass:  <asp:CompareValidator ID="compass" runat="server" ErrorMessage="Password And Re-Password Must be Same" ControlToCompare="txtrepassword" ForeColor="Red" ControlToValidate="txtpassword"></asp:CompareValidator>
Range:  <asp:RangeValidator ID="rangesalary" runat="server" ForeColor="Red" MaximumValue="100000" MinimumValue="25000" ErrorMessage="25000 to 100000" ControlToValidate="txtsalary" Type="Integer"></asp:RangeValidator>


// Ajax
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
			<asp:Button ID="btnsubmit" CssClass="btn btn-primary" OnClick="btnsubmit_Click" runat="server" Text="Submit" />
        </ContentTemplate>
    </asp:UpdatePanel>


// Login
string query = "select name,password from Login where name='" + txtusername.Text.Trim() + "'";
SqlCommand cmd = new SqlCommand(query, con);
SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
	if (dr.GetValue(0).ToString() == txtusername.Text.Trim() && dr.GetValue(1).ToString() == txtpass.Text)
    {
        Session["uname"] = txtusername.Text;
        Response.Redirect("View.aspx");
    }
    else
    {
        Response.Write("<script>alert('Invalid Credential');</script>");
    }
}
else
{
    //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "showError();", true);
    Response.Write("<script>alert('Invalid Credential');</script>");
}

// Session
Session.Abandon();

// Cookie
Response.Cookies["name"].Value = "dsc";
string User_Name = Request.Cookies["userName"].Value; 
Response.Cookies["name"].Expires = DateTime.Now.AddMinutes(2000);

// Query String
Response.Redirect("default2.aspx ?firstname=" + TextBox1.Text + "&lastname=" + TextBox2.Text);
string firstname = Request.QueryString["firstname"];
string lastname = Request.QueryString["lastname"]; 

// Insert
static string constr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Employee.mdf;Integrated Security=True";
SqlConnection con = new SqlConnection(constr);
			con.Open();
            string query = "insert into emp(name,DOB,City,email,password,mobile,salary) values(@name,@dob,@city,@email,@password,@mobile,@salary)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@dob", txtdob.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@salary", txtsalary.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script>alert('Record Inserted');</script>");

// Update
string query = "update emp set name='" + txtname.Text + "',DOB='" + txtdob.Text + "',City='" + txtcity.Text + "',email='" + txtemail.Text + "',password='" + txtpassword.Text + "',mobile='" + txtmobile.Text + "',salary='" + txtsalary.Text + "' where Id='" + txtid.Text + "'";
SqlCommand cmd = new SqlCommand(query, con);
cmd.ExecuteNonQuery();
Response.Write("<script>alert('Record Updated...')</script>");
con.Close();

// Search in textbox
SqlCommand cmd=new SqlCommand("select * from stud where id='"+txtid.text+"'",con);
SqlDataReader dr=cmd.ExecuteReader();
if(dr.Read())
{
	txtname.text=dr.getValue(1).toString();
}

// Search in GridView
SqlCommand cmd=new SqlCommand("select * from stud where id='"+txtid.text+"'",con);
SqlDataAdapter da=new SqlDataAdapter(cmd);
DataTable dt=new DataTable();
da.Fill(dt);
GridView1.DataSource=dt;
GridView1.DataBind();
